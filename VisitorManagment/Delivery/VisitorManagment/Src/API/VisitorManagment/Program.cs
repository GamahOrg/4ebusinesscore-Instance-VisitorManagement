using _4EPlatform.Application;
using _4EPlatform.Application.Helpers;
using _4EPlatform.Application.Mappings;
using _4EPlatform.PermissionsGroupingChecker;
using _4EPlatForm.Infrastructure.Interface;
using _4EPlatform_Controlpanel_ORGHierararchy;
using _4EPlatform_Controlpanel_ORGHierararchy.Services;
using _4EPlatform_Controlpanel_WorkSpace.GrpClientsConfig;
using _4EPlatform_VisitorManagement.Extention;
using Autofac.Core;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
try
{
    var logger = new LoggerConfiguration()
          .ReadFrom.Configuration(builder.Configuration)
          .Enrich.FromLogContext()
          .CreateLogger();
    builder.Host.UseSerilog(logger);

    builder.Services.AddGrpc();
    builder.Services.AddGrpcReflection();

    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(ApplicationLayer)));
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.Listen(IPAddress.Any, 7121, o => o.Protocols = HttpProtocols.Http2);

        // ADDED THIS LINE to fix the problem
        options.Listen(IPAddress.Any, 5149, o => o.Protocols = HttpProtocols.Http1);
    });


    // Add services to the container.
    //builder.Host.UseSerilog((ctx, lc) => lc
    //    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
    //    .Enrich.FromLogContext()
    //    .ReadFrom.Configuration(ctx.Configuration));

    // solve the problem of cycle

    builder.Services.AddControllersWithViews()
     .AddNewtonsoftJson(options =>
     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
 );

    builder.Services.AddDbContext<DBContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

        options.EnableSensitiveDataLogging(true);
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    });
    //builder.Services.AddHangfire(opts =>
    //{
    //    opts.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"));
    //});
    //builder.Services.AddHangfireServer();

    builder.Services.AddMediatR(cfg =>
    {
        cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
    });
    builder.Services.AddMediatR(cfg =>
    {
        cfg.RegisterServicesFromAssembly(typeof(CoreModule).Assembly);
    });
    builder.Services.AddUnitOfWorkRepositry();
    builder.Services.AddAutoMapper(typeof(ApplicationLayer));
    builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    //builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    //builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(SendNotificationHandler).GetTypeInfo().Assembly));
    //builder.Services.AddMediatR(AppDomain.CurrentDomain.Load("4EPlatform.Application"));
    builder.Services.AddScoped<IEmailSender, EmailSender>();
    // builder.Services.AddAutoMapper(typeof(Program), typeof(CoreModule));
    builder.Services.AddTransient<ResponseDTO>();
    builder.Services.AddDbConfig(builder.Configuration);

    builder.Services.AddControllers().AddOData(options =>
                options.Select().Filter().OrderBy().Expand());
    builder.Services.AddHttpContextAccessor();    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
    builder.Services.AddTransient<IAESConfiguration, AESConfiguration>();
    builder.Services.AddSingleton<IAESConfiguration>(builder.Configuration.GetSection("EncryptionConfiguration").Get<AESConfiguration>());

    builder.Services.AddSingleton<IEmailConfiguration>(
    builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
    builder.Services.AddScoped<IEmailService, EmailService>();
    builder.Services.AddScoped<IResponseHelper, ResponseHelper>();
    //builder.Services.AddScoped<UpdateStatus>();
    builder.Services.AddGrpc();
    builder.Services.AddSignalR();
    builder.Services.AddUserManagementGrpcClients(builder.Configuration["GrpcServiceSettings:UserManagementUrl"]);
    builder.Services.AddSingleton<ITokenService, TokenService>();
    builder.Services.AddHostedService<AddPermissionsMiddleware>();
    builder.Services.AddScoped<PermissionsGroupingCheckerMiddleware, PermissionsGroupingCheckerMiddleware>();
    builder.Services.AddAutoMapper(typeof(MappingProfile));

    #region Localization
    builder.Services.AddSingleton<LocService>();
    builder.Services.AddHostedService<AddPermissionsMiddleware>();
    #endregion

    //Identity Server
    builder.Services.AddIdentityServer()
    .AddInMemoryClients(IdentityConfiguration.Clients)
    .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
    .AddInMemoryApiResources(IdentityConfiguration.ApiResources)
    .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
    // use identity user in database 
    .AddDeveloperSigningCredential();



    builder.Services.AddApiVersioning(config =>
    {
        // Specify the default API Version as 1.0
        config.DefaultApiVersion = new ApiVersion(1, 0);
        // If the client hasn't specified the API version in the request, use the default API version number 
        config.AssumeDefaultVersionWhenUnspecified = true;
        // Advertise the API versions supported for the particular endpoint
        config.ReportApiVersions = true;
    });
    #region Swagger
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Visitor APIs Reference",
        });

        c.AddSecurityDefinition(
        "token",
        new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer",
            In = ParameterLocation.Header,
            Name = HeaderNames.Authorization
        }
            );
        c.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "token"
                            },
                        },
                        Array.Empty<string>()
                    }
        }
            );
    });
    #endregion
    builder.Services.Configure<IdentityOptions>(options =>
    {
        // Password settings
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;

        // Lockout settings
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(10);
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.AllowedForNewUsers = true;

        // User settings
        options.User.RequireUniqueEmail = true;
    });


    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowCors",
            builder =>
            {
                builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("http://localhost:3000")
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials();
            });
    });






    builder.Services.AddApiVersioning(config =>
    {
        // Specify the default API Version as 1.0
        config.DefaultApiVersion = new ApiVersion(1, 0);
        // If the client hasn't specified the API version in the request, use the default API version number
        config.AssumeDefaultVersionWhenUnspecified = true;
        // Advertise the API versions supported for the particular endpoint
        config.ReportApiVersions = true;
    });
    builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

    builder.Services.AddMvc()
        .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
        // .AddDataAnnotationsLocalization();
        .AddDataAnnotationsLocalization(options =>
        {
            options.DataAnnotationLocalizerProvider = (type, factory) =>
            {
                var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
                return factory.Create("SharedResource", assemblyName.Name);
            };
        });

    builder.Services.Configure<RequestLocalizationOptions>(options =>
    {
        var supportedCultures = new[]
        {
                    new CultureInfo("en-US"),
                    new CultureInfo("ar"),
                    new CultureInfo("de"),
                    new CultureInfo("fr"),
                    new CultureInfo("es")
                };

        options.DefaultRequestCulture = new RequestCulture(culture: "ar", uiCulture: "ar");
        options.SupportedCultures = supportedCultures;
        options.SupportedUICultures = supportedCultures;
    });


    // builder.Host.UseSerilog();

    builder.Services.AddAuthentication("Bearer")
      .AddJwtBearer("Bearer", options =>
      {
          // the name of your api resources   
          options.Audience = "UserManagementServer";
          /// identity server url                    
          options.Authority = builder.Configuration.GetValue<string>("IdentityUrl");
          options.RequireHttpsMetadata = false;
      });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("ResourceOwnerPolicy", policy =>
        {
            policy.AddAuthenticationSchemes("Bearer");
            policy.RequireClaim("scope", "4EMicroServices"); // Require scope associated with Resource Owner Password token
        });

        options.AddPolicy("ClientCredentialsPolicy", policy =>
        {
            policy.AddAuthenticationSchemes("Bearer");
            policy.RequireClaim("scope", "CPAggregatorAPI"); // Require scope associated with Client Credentials token
        });
    });

    //builder.Services.AddHostedService<TestJobs>();
    var app = builder.Build();
    app.AddMapGrpcServices();
    // Configure the HTTP request pipeline.
    //if (app.Environment.IsDevelopment())
    //{
    app.UseSwagger();
    app.UseSwaggerUI();
    //}

    // app.UseHangfireDashboard("/dashborad");
    //app.MapHangfireDashboard();

    using (var serviceScope = app.Services.CreateScope())
    {
        var dbContext = serviceScope.ServiceProvider.GetRequiredService<DBContext>();
        var serviceProvider = serviceScope.ServiceProvider;
        if (!serviceScope.ServiceProvider.GetService<DBContext>().AllMigrationsApplied())
        {
            serviceScope.ServiceProvider.GetService<DBContext>().Migrate();
        }
        ContextSeedData.Seed(dbContext, serviceProvider,builder.Configuration);
    }

    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
        RequestPath = "/wwwroot"
    });
    app.UseCors("AllowCors");
    //app.UseCors();
    app.UseApiVersioning();
    app.MapControllers();
    app.UseSerilogRequestLogging();
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }



    app.UseStaticFiles();
    app.UseRouting();
    app.UseIdentityServer();
    //app.MapGrpcService<PermissionVistor>();

    //app.UseSerilogRequestLogging();

    //app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    //app.UseMiddleware<PermissionsGroupingCheckerMiddleware>();

    app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());


    app.Run();
}
catch (Exception ex) when (

// https://github.com/dotnet/runtime/issues/60600
ex.GetType().Name is not "StopTheHostException"
    // HostAbortedException was added in .NET 7, but since we target .NET 6 we
    // need to do it this way until we target .NET 8
    && ex.GetType().Name is not "HostAbortedException")
{
    Console.WriteLine(ex.Message);
    Log.Fatal(ex, "Unhandled exception");
}