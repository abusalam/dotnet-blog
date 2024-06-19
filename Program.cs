using Microsoft.EntityFrameworkCore;
using MyBlogAPI8.Migrations.DBContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyBlogContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("EMCon")));


// Add services to the container.

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

app.UseAuthorization();

app.MapControllers();

app.Run();
