using green_basket.Server.Repository.bill_details;
using green_basket.Server.Repository.current_user_session;
using green_basket.Server.Repository.order;
using green_basket.Server.Repository.user;
using green_basket.Server.Repository.user.Interface;
using green_basket.Server.Service.BillService;
using green_basket.Server.Service.CurrentUserSessionService;
using green_basket.Server.Service.orderService;
using green_basket.Server.Service.userService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
}); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the UserRepository and UserService
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();
builder.Services.AddScoped<IBillDetailsRepository,bill_detailsRepository>();
builder.Services.AddScoped<IBillDetailsService, BillDetailsService>();
builder.Services.AddScoped<ICurrentUserSessionRepo, CurrentUserSessionRepo>();
builder.Services.AddScoped<ICurrentUserSession, CurrentUserSessionService>();

// Configure CORS policy (optional)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll"); // Apply CORS policy

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
