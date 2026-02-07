using MeuCorre.Application;
using MeuCorre.Domain.Interfaces.Repositories;
using MeuCorre.Infra;
using MeuCorre.Infra.Repositories;

namespace MeuCorre
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // --- 1. CONFIGURAÇÃO DE SERVIÇOS (DI Container) ---

            builder.Services.AddControllers();

            // Configurações das suas camadas de Infra e Application
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication(builder.Configuration);

            // REGISTRO DO REPOSITÓRIO: Deve estar ANTES do builder.Build()
            builder.Services.AddScoped<ITagRepository, TagRepository>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("DefaultPolicy", policy => // Nomeado como "DefaultPolicy" para clareza
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // --- 2. CONSTRUÇÃO DO APLICATIVO ---
            // Após esta linha, você não pode mais usar builder.Services
            var app = builder.Build();

            // --- 3. CONFIGURAÇÃO DO PIPELINE DE REQUISIÇÕES (Middlewares) ---

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Use o nome da política definida acima ou a string "*" se manteve assim
            app.UseCors("DefaultPolicy");

            app.UseAuthorization();

            app.MapControllers();

            // O comando Run() é o fim da linha, ele trava o console para rodar a API
            app.Run();
        }
    }
}