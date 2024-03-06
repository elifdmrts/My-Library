using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using WebApplicationYeni.Models;
using WebApplicationYeni.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
       options.UseSqlServer(builder.Configuration["ConnectionStrings:AppConnectionString"],
       options =>
       {
           options.EnableRetryOnFailure();    
       }));

builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddScoped<IWriterService, WriterService>();


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
