using GraphQLTestingAPI;
using GraphQLTestingAPI.AppContext;
using GraphQLTestingAPI.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services
    .AddGraphQLServer()
    .AddErrorFilter<GraphQLErrorFilter>()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true)
    .RegisterDbContext<AppDbContext>(DbContextKind.Pooled)
    .AddQueryType(q => q.Name("query"))
    .AddType<PostQuery>()
    .AddType<AuthorQuery>()
    .AddMutationType(x => x.Name("mutation"))
    .AddType<PostMutation>()
    .AddType<AuthorMutation>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();
builder.Services.AddPooledDbContextFactory<AppDbContext>(options => options.UseSqlite("Data Source=helloapp.db"));
var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.MapGraphQL();    
app.Run();