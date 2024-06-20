using Microsoft.EntityFrameworkCore;
using MyBlogAPI8.BAL.IServices;
using MyBlogAPI8.BAL.Services;
using MyBlogAPI8.DAL.IRepository;
using MyBlogAPI8.DAL.Repository;
using MyBlogAPI8.Migrations.DBContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyBlogContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("BlogCon")));

//AutoMapper 
builder.Services.AddAutoMapper(typeof(Program));

//Repositories
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IPostRepository, PostRepository>();

//Services
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IPostService, PostService>();

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

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
