using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microshoppy.Sales
{
	public static class ProdLogger
	{
		public static void Info(this ILogger logger, string info)
		{
			logger.Log(LogLevel.Information, $"[INFO] {info}");
		}
	}
}
