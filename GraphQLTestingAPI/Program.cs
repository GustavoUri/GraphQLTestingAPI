using GraphQLTestingAPI;
using GraphQLTestingAPI.AppContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddGraphQLServer()
    //.RegisterDbContext<AppDbContext>()
    .AddQueryType<Query>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql("server=172.16.100.102;uid=root;pwd=1;database=graphqlapitesting;", 
    new MySqlServerVersion(new Version(8, 0, 11))));
var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.MapGraphQL();    
app.Run();