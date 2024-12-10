
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MyToDoListApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicyLocalFile",
                    policy =>
                    {
                        //policy.WithOrigins("file:///C:/prodzekty/MyToDoListApp").AllowAnyHeader().AllowAnyMethod();
                        policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                    });

                options.AddPolicy("CorsPolicyGitHub",
                    policy =>
                    {
                        policy.WithOrigins("http://www.github.com")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseRouting();
            app.UseCors();
            
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            
            app.Run();
        }
    }
}
