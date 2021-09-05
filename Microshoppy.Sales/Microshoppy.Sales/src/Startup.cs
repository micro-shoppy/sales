using System;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MediatR;
using Microshoppy.Sales.CQRS.Command;
using Microshoppy.Sales.Repositories;

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
			services.AddTransient<ISalesRepository, InMemorySalesRepository>();
			services.AddMediatR(typeof(CreateSalesProductCommand));
			var rabbitOptions = new RabbitMqOptions();
			Configuration.GetSection("RabbitMq").Bind(rabbitOptions);
			services.AddMassTransit(x =>
			{
				x.AddConsumer<ProductCreatedConsumer>();
				x.AddConsumer<ProductRemovedConsumer>();
				x.UsingRabbitMq((context, cfg) =>
				{
					cfg.Host(new Uri(rabbitOptions.Host));
					cfg.ConfigureEndpoints(context);
				});
			});
			services.AddMassTransitHostedService();
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
