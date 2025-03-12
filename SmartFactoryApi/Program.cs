
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using SmartFactory.BusinessInterface;
using SmartFactory.BusinessService;
using SmartFactoryApi.Utility.Filter;
using SmartFactoryApi.Utility.SwaggerExt;
using SqlSugar;
using System.Reflection;

namespace SmartFactoryApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //nuget“˝»Î:log4net
            //          Microsoft.Extensions.Logging.Log4Net.AspNetCore 
            builder.Logging.AddLog4Net("CfgFile/log4net.config");
           
            builder.Services.AddScoped<IAttendanceService, AttendanceService>();
            builder.Services.AddTransient<ISystemlogService,SystemlogService>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<ISqlSugarClient>(
                obj =>
                {
                    ConnectionConfig connection = new ConnectionConfig()
                    {
                        ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection"),
                        DbType = DbType.SqlServer,
                        IsAutoCloseConnection = true,
                        InitKeyType = InitKeyType.Attribute
                    };
                    return new SqlSugarClient(connection);
                }
                );
            builder.Services.AddAutoMapper(typeof(AutoMapperConfigs));

            builder.Services.AddControllers(option=>
            {
                //option.Filters.Add<CustomAlwaysOnResultFilterAttribute>();
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddCors(
                option =>
                {
                    option.AddPolicy("any", builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    }
                    );
                    })
                ;

                    //Swagger≈‰÷√
                    builder.AddSwagger();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerExt();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("any");

            app.MapControllers();

            app.Run();
        }
    }
}
