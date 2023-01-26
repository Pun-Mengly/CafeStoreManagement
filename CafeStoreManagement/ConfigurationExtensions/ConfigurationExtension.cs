
public static class ConfigurationExtension
{
    public static IServiceCollection AddService(this IServiceCollection services)
        {
            #region Depandecy Injection
            services.AddScoped<ResponseModel>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IBusinessLogic, BusinessLogic>();
            services.AddTransient<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>()!.HttpContext!.User);

        #endregion
        #region Config JWT
        // For Identity
        var builder = WebApplication.CreateBuilder();
        ConfigurationManager configuration = builder.Configuration;
        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();


        // Adding Jwt Bearer
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = configuration["JWT:ValidAudience"],
                ValidIssuer = configuration["JWT:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
            };
        });
        //------------------Decoration swagger-------------
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "CafeStoreManagerment", Version = "v2" });
        });
        services.AddSwaggerGen(options => {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                    Reference = new OpenApiReference {
                        Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                    }
                },
                    new string[] {}
                }
            });
        });
        //-----------------------------------------------------------

        //services.Configure<DataProtectionTokenProviderOptions>(options =>
        //{
        //    options.TokenLifespan = TimeSpan.FromMinutes(5);
        //});
        //services.AddIdentity<ApplicationUser, IdentityRole>()
        //.AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();


        #endregion





        return services;
        }
}
