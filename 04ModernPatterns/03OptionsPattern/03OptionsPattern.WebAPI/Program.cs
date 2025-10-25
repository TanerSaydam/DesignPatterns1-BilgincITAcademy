using _03OptionsPattern.Infrastructure;
using _03OptionsPattern.Infrastructure.Options;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
builder.Services.ConfigureOptions<JwtOptionsSetup>();

//builder.Configuration.GetConnectionString("SqlServer");
//builder.Configuration.GetSection("Jwt:Issuer");
//builder.Configuration.GetSection("Jwt:Aduience");
//builder.Configuration.GetSection("Jwt:SecretKey");

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

builder.Services.AddTransient<JwtProvider>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("login", (JwtProvider jwtProvider) =>
{
    return Results.Ok(jwtProvider.CreateToken());
});

app.MapGet("/test", (IOptionsMonitor<JwtOptions> options) =>
{
    var jwtOptions = options.CurrentValue;
    return Results.Ok();
}).RequireAuthorization();

app.Run();
