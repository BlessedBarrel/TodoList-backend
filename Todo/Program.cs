using ApplicationLayer.Interface;
using ApplicationLayer.Services;
using InfastructureLayer.Database;
using InfastructureLayer.Repository;
using InfastructureLayer.Services.interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>( o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);


builder.Services.AddScoped<ITodoListServices,TodoServices>();
builder.Services.AddScoped( typeof(IRepositoryPattern<>) , typeof(RepositoryPattern<>) );
builder.Services.AddControllers();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
// app.UseHttpsRedirection();

app.Run();


