using Microsoft.EntityFrameworkCore;
using PessoasContatosAPI.Data;
using PessoasContatosAPI.Models;

namespace PessoasContatosAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();
            builder.Services.AddControllers()
            .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; });
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<PessoasContatosContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ServerConnection")));

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                SeedData.Initialize(services);
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=PessoasCotroller}/{action=Index}/{id?}");

            app.Run();
        }
    }
}