using Golden;
using Golden.Entities;
using Golden.Repository;
using Golden.Repository.IRepository;
using Golden.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var key = "hdscjasjfhklasjfhSSdfjfjsdjr884237hwd58W73R3QWEJD";
var KeyByte = Encoding.ASCII.GetBytes(key);
builder.Services.AddControllersWithViews();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();ApplicationDbContext
builder.Services.AddSwaggerGen(c =>
{
    // ... ≈⁄œ«œ«  √Œ—Ï
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
});


builder.Services.AddScoped<IClientRepository1, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IResponsibleRepository, ResponsibleRepository>();
builder.Services.AddScoped<IResponsibleService, ResponsibleService>();

builder.Services.AddScoped<IServicesRepository, ServicesRepository>();
builder.Services.AddScoped<ISevicesService, SevicesService>();
//add authentication setting
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
//    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Description = "JWT Authorization header using the Bearer scheme.",
//        Type = SecuritySchemeType.Http,
//        Scheme = "Bearer"
//    });
//    c.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = "Bearer"
//                }
//            },
//            new string[] {}
//        }
//    });
//});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// add services application.json
var SiteUrl = builder.Configuration["SiteUrl"];
//builder.Services.AddAuthentication()
//    .Add[SomeAuthHandler]("Bearer", options =>
//    {
//        // Configure the options for your authentication handler
//    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminAcess", policy => policy.RequireRole("Admin"));
    //options.AddPolicy("CustomerAcess", policy => policy.RequireRole("Customer"));

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseRouting();
//app.UseSession();
app.UseCors(x =>
{
    x.AllowAnyOrigin();
    x.AllowAnyHeader();
    x.AllowAnyMethod();
});
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
if (!app.Environment.IsProduction())
{
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetService<ApplicationDbContext>();

        //db.Database.Migrate();
        var check = db.admin.FirstOrDefault(x => x.UserName == "SuperAdmin@gmail.com" && x.Password == "Admin123");
        if (check == null)
        {
            var item = new Admin()
            {
                UserName = "SuperAdmin@gmail.com",
                Password = "Admin123",
                 Role= "Admin",
            };
            db.admin.Add(item);
            db.SaveChanges();


        }

    }
}

app.Run();
