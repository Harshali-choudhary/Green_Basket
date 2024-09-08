
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using System.Reflection;
using green_basket.Server.Repository.user.Interface;
using green_basket.Server.Repository.user;
using green_basket.Server.Service.userService;
using green_basket.Server.Repository.vegetable.Interface;
using green_basket.Server.Repository.vegetable;
using green_basket.Server.Service.VegetableService;
using green_basket.Server.Repository.Cart_Vegetable.Interface;
using green_basket.Server.Service.CartVegetableService;
using green_basket.Server.Repository.Feedback.Interface;
using green_basket.Server.Repository.Cart_Vegetable;
using green_basket.Server.Service.Feedback;
using green_basket.Server.Repository.Feedback;
using green_basket.Server.Repository.Cart.Interface;
using green_basket.Server.Repository.Cart;
using green_basket.Server.Service.Cart_orderService;
using green_basket.Server.Service.orderService;
using green_basket.Server.Repository.order;
using green_basket.Server.Repository.bill_details;
using green_basket.Server.Service.BillService;
using green_basket.Server.Repository.current_user_session;
using green_basket.Server.Service.CurrentUserSessionService;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "A simple example ASP.NET Core Web API"
    });

    // Optionally include XML comments if you have them
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

// Register repositories and services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IVegetableRepository, VegetableRepository>();
builder.Services.AddScoped<IVegetableService, VegetableService>();
builder.Services.AddScoped<ICartVegetablesRepository, CartVegetableRepository>();
builder.Services.AddScoped<ICartVegetableService, CartVegetableService>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<ICartOrderRepository, CartOrderRepository>();
builder.Services.AddScoped<ICartOrderService, CartOrderService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IBillDetailsRepository, bill_detailsRepository>();
builder.Services.AddScoped<IBillDetailsService, BillDetailsService>();
builder.Services.AddScoped<ICurrentUserSessionRepo, CurrentUserSessionRepo>();
builder.Services.AddScoped<ICurrentUserSession, CurrentUserSessionService>();

// Configure JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"]
    };
});

// Configure CORS
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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Serve React app for any unknown routes
app.MapFallbackToFile("index.html"); // Adjust if necessary based on your build output directory

app.Run();
