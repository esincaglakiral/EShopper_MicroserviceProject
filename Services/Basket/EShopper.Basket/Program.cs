using EShopper.Basket.Services;
using EShopper.Basket.Services.IdentityServices;
using EShopper.Basket.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IBasketService,BasketService>();

builder.Services.AddScoped<IIdentityService,IdentityService>();

builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection("RedisSettings"));

builder.Services.AddSingleton<RedisService>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;  //redis settings içerisinde propertylerin deðerleri
    var redis = new RedisService(settings.Host, settings.Port);
    redis.Connect();
    return redis;
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.MapInboundClaims = false;
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "resource_basket";
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();  //Authentication middleware'i her zmana UseAuthorization'dan önce gelir

app.UseAuthorization();

app.MapControllers();

app.Run();
