using ListaDeTarefa.Application.Interfaces.IRepository;
using ListaDeTarefa.Application.Interfaces.IServices;
using Microsoft.Extensions.DependencyInjection;
using ListaDeTarefa.Infrastructure.Repository;
using ListaDeTarefa.Infrastructure.Context;
using ListaDeTarefa.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefa.Infrastructure.DependencyInjection
{
	public static class ServiceCollectionExtensions
	{
		//public static IServiceCollection AddProjectDependencies(this IServiceCollection services, string connectionString)
		//{
		//	services.AddDbContext<ListaDeTarefaContexto>(options =>
		//		options.UseSqlServer(connectionString));

		//	services.AddScoped<ITarefaRepository, TarefaRepository>();
		//	services.AddScoped<ITarefaService, TarefaService>();


		//	return services;
		//}

		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("ListaDeTarefaConnection");

			// 🔍 DIAGNÓSTICO 
			Console.WriteLine("=================================");
			Console.WriteLine($"Connection String: {connectionString}");
			Console.WriteLine("=================================");

			services.AddDbContextPool<ListaDeTarefaContexto>(options =>
				options.UseSqlServer(connectionString)
						.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)

			);

			services.AddMemoryCache();
			services.AddHealthChecks().AddDbContextCheck<ListaDeTarefaContexto>("ListaDeTarefa BD");

			services.AddScoped<ITarefaRepository, TarefaRepository>();
			services.AddScoped<ITarefaService, TarefaService>();

			return services;
		}
	}
}
