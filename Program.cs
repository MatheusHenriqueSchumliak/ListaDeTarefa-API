using ListaDeTarefa.Infrastructure.DependencyInjection;
using ListaDeTarefa.Application.DependencyInjection;
using System.Text.Json.Serialization;

namespace ListaDeTarefa_API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();

			builder.Services.AddValidationServices();
			//builder.Services.AddProjectDependencies();
			builder.Services.AddInfrastructureServices(builder.Configuration);

			builder.Services.AddControllers()
					.AddJsonOptions(options =>
					{
						options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
					});

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
