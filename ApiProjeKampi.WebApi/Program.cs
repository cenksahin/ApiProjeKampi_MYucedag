using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using ApiProjeKampi.WebApi.ValidationRules;
using FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

//swagger ekle
builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

//ekle
builder.Services.AddDbContext<ApiContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//ekle FluentValidation
builder.Services.AddScoped<IValidator<Product>, ProductValidator>();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    //swagger ekle
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();