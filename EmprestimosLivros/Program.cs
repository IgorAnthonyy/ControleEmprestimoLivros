using Microsoft.EntityFrameworkCore;
using EmprestimosLivros.Data;
using EmprestimosLivros.Repositorios;
using EmprestimosLivros.Repositorios.Interface;
using EmprestimosLivros.Email;

namespace EmprestimosLivros
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(LivroProfile));
            builder.Services.AddScoped<EmailService>();

            builder.Services.AddDbContext<EmprestimosLivrosDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            builder.Services.AddScoped<IEmprestimoRepositorio, EmprestimoRepositorio>();
            builder.Services.AddScoped<ILivroRepositorio, LivroRepositorio>();

            var app = builder.Build();

            if(app.Environment.IsDevelopment())
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