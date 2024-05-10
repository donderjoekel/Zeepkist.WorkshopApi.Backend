using System.Text.Json;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Authentication;
using NSwag;
using Serilog;
using TNRD.Zeepkist.WorkshopApi.Backend.Authentication;
using TNRD.Zeepkist.WorkshopApi.Backend.Extensions;
using TNRD.Zeepkist.WorkshopApi.Backend.Google;
using TNRD.Zeepkist.WorkshopApi.Database;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.AddServerHeader = false;
    options.AllowSynchronousIO = false;
});

builder.Host.UseConsoleLifetime(options => options.SuppressStatusMessages = true);

builder.Host.UseSerilog((context, configuration) =>
{
    configuration
        .Enrich.FromLogContext()
        .Enrich.WithProperty("Source", "Zworpshop.Api")
        .MinimumLevel.Debug()
        .WriteTo.Seq(context.Configuration["Seq:Url"], apiKey: context.Configuration["Seq:Key"])
        .WriteTo.Console();
});

builder.Services.AddNpgsql<ZworpshopContext>(builder.Configuration["Database:ConnectionString"]);

builder.Services.AddAuthentication(ApiKeyAuthentication.SCHEME)
    .AddScheme<AuthenticationSchemeOptions, ApiKeyAuthentication>(ApiKeyAuthentication.SCHEME, null);
builder.Services.AddAuthorization();

builder.Services.AddFastEndpoints(options =>{});
// builder.Services.AddFastEndpoints(options => { options.SourceGeneratorDiscoveredTypes = new Type[] { }; });

builder.Services.SwaggerDocument(o =>
{
    o.EnableJWTBearerAuth = false;
    o.DocumentSettings = s =>
    {
        s.Title = "Zworpshop API";
        s.AddAuth(ApiKeyAuthentication.SCHEME,
            new()
            {
                Name = ApiKeyAuthentication.HEADER,
                In = OpenApiSecurityApiKeyLocation.Header,
                Type = OpenApiSecuritySchemeType.ApiKey
            });
    };
});

builder.Services.Configure<GoogleOptions>(builder.Configuration.GetSection("Google"));
builder.Services.AddSingleton<IUploadService, CloudStorageUploadService>();

builder.Services.AddCors();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDefaultExceptionHandler();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseFastEndpoints(options =>
{
    options.Errors.ResponseBuilder = (errors, _, _) => errors.ToResponse();
    options.Errors.StatusCode = StatusCodes.Status422UnprocessableEntity;
    options.Serializer.Options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

app.UseCors(policyBuilder => policyBuilder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseOpenApi();
// app.UseSwaggerUi3()
app.UseSwaggerUi(x => x.ConfigureDefaults());
// app.UseSwaggerUi3(x => x.ConfigureDefaults());

using (IServiceScope serviceScope = app.Services.CreateScope())
{
    ZworpshopContext workshopApiContext = serviceScope.ServiceProvider.GetRequiredService<ZworpshopContext>();
    workshopApiContext.Database.EnsureCreated();
}

await app.RunAsync();
