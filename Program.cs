using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using H24_4204W6ProgWebServices_Labo08.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<H24_4204W6ProgWebServices_Labo08Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("H24_4204W6ProgWebServices_Labo08Context") ?? throw new InvalidOperationException("Connection string 'H24_4204W6ProgWebServices_Labo08Context' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// CORS (Cross-Origin Resource Sharing)
builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow all", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    }
    );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS (Cross-Origin Resource Sharing)
app.UseCors("Allow all");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
