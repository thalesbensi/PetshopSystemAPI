using Microsoft.EntityFrameworkCore;
using PetshopAPISystem.Domain.Contexts;
using PetshopAPISystem.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddScoped<PetService>();
builder.Services.AddScoped<TutorService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("PetshopDb"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
