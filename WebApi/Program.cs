using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApi.Data;
using WebApi.Mapper;
using WebApi.Models;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(EmployeeLoginModel));

var connectionString = builder.Configuration.GetConnectionString("MsSqlConnection");
builder.Services.AddDbContext<emsDbContext>(options => options.UseSqlServer(connectionString));

// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => 
// {
//     opt.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateAudience = true,
//         ValidateIssuer = true,
//         ValidateLifetime =true,
//         ValidateIssuerSigningKey = true,
//         ValidIssuer = configuration["Token:Issuer"],
//         ValidAudience = configuration["Token:Audience"],
//         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"])),
//         ClockSkew = TimeSpan.Zero  //Üretilecek token değerinin expire süresinin belirtildiği değer kadar uzatılmasını sağlayan özelliktir
        
//     };
// });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
