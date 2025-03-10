using Microsoft.OpenApi.Models;

namespace SmartFactoryApi.Utility.SwaggerExt
{
    /// <summary>
    /// 这个类扩展了swagger的相关配置
    /// </summary>
    public static class CustomSwaggerExt
    {   /// <summary>
    /// ----------------------------------------配置Swagger---------------------------------------------
    /// </summary>
    /// <param name="builder"></param>
        public static void AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = $"实战项目Api文档",
                    Version = "v1",
                    Description = $"通用的CoreApi版本v1"
                });
                //AppContext.BaseDirectory 是一个静态属性，它返回当前应用程序的基目录
                var file = Path.Combine(AppContext.BaseDirectory, "SmartFactoryApi.xml");
                //true表示显示控制器的注释
                options.IncludeXmlComments(file, true);
                //对action的名称进行排序
                options.OrderActionsBy(o => o.RelativePath);
                //                AddSecurityDefinition 的实际作用
                //                告诉 Swagger 这个 API 需要某种认证方式。
                //                在 Swagger UI 里显示一个 "Authorize" 按钮，允许用户输入 Token 进行身份认证。
                //                让 Swagger 在请求 API 时自动附加身份认证信息（例如 Authorization: Bearer < token >）。
                //                与 AddSecurityRequirement 结合使用，确保 API 需要 Token 才能访问。



                //---------------------------添加安全定义--------------------------------------
                //OpenApiSecurityScheme 类是在使用 OpenAPI 规范来描述 API 时，用于定义 API 安全机制的一个重要类。
                //它通常在生成 API 文档（如 Swagger 文档）时使用，
                options.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "请输入token格式为Bearer xxxxxxxx（中间必须有空格）",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        BearerFormat = "JWT",
                        Scheme = "Bearer"
                    });


                //---------------------------添加安全要求----------------------------------------
                //OpenApiSecurityRequirement 是一个表示安全要求的类，它是一个键值对的集合。
                //键是 OpenApiSecurityScheme 类型，表示安全方案；
                //值是一个字符串数组，表示该安全方案适用的作用域（scopes）。
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                                 Reference = new OpenApiReference
                             {
                                 Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer" // 这里的 Id 必须和 AddSecurityDefinition 里的名称一致
                             }
                         },
                         new string[] { } // 空数组表示所有 API 都适用
                     }
                 });
            });
        }
        /// <summary>
        /// 使用Swagger
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwaggerExt(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
