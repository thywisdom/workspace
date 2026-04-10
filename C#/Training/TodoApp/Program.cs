
using Microsoft.EntityFrameworkCore;
using ToDoApp.MappingProfiles;
using ToDoApp.Middlewares;
using ToDoApp.Services;
using ToDoApp.Models;
using ToDoApp.Data;
using TodoApp.Middlewares;
using Microsoft.AspNetCore.Authentication;
using TodoApp.Services;


namespace ToDoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddProblemDetails();  
            builder.Services.AddLogging();  
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            builder.Services.AddScoped<ITodoServices, TodoServices>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<TokenService>();
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

            builder.Services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, GlobalAuthenticationHandler>("BasicAuthentication", options => { });

            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("constr"))
            );


            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseExceptionHandler(); 
             
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}