using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MediatR;
using Microshoppy.Sales.CQRS.SalesProducts.Commands;
using Microshoppy.Sales.Entities;
using Microshoppy.Sales.MessageConsumers;
using Microshoppy.Sales.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Microshoppy.Sales
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Microshoppy.Sales", Version = "v1" });
			});
			services.AddTransient<IRepository<SalesProduct>, InMemorySalesRepository>();
			services.AddTransient<IRepository<Order>, InMemoryOrdersRepository>();
			services.AddMediatR(typeof(CreateSalesProductCommand));

			// Add RabbitMq/MassTransit 
			var rabbitOptions = new RabbitMqOptions();
			Configuration.GetSection("RabbitMq").Bind(rabbitOptions);
			services.AddMassTransit(x =>
			{
				x.AddConsumer<ProductCreatedConsumer>();
				x.AddConsumer<ProductRemovedConsumer>();
				x.AddConsumer<OrderBilledConsumer>();
				x.UsingRabbitMq((context, cfg) =>
				{
					cfg.Host(new Uri(rabbitOptions.Host));
					cfg.ConfigureEndpoints(context);
				});
			});
			services.AddMassTransitHostedService();

			// Add Auth
			var authSection = Configuration.GetSection("AuthOptions");
			var authOptions = authSection.Get<AuthOptions>();
			services.Configure<AuthOptions>(authSection);
			JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
			services.AddAuthentication(options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(jwt =>
				{
					var key = Encoding.ASCII.GetBytes(authOptions.Key);

					jwt.SaveToken = true;
					jwt.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(key),
						ValidateIssuer = false,
						ValidateAudience = false,
						RequireExpirationTime = true,
						ValidateLifetime = true
					};
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Microshoppy.Sales v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
