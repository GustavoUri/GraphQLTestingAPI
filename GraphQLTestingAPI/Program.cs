using GraphQLTestingAPI;
using GraphQLTestingAPI.GraphQL;
using GraphQLTestingAPI.GraphQL.Queries;
using GraphQLTestingAPI.GraphQL.Subscriptions;
using GraphQLTestingAPI.Services;
using GraphQLTestingDataLayer.AppContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddScoped<AuthorService>();
//builder.Services.AddSwaggerGen();
builder.Services
    .AddGraphQLServer()
    .AddErrorFilter<GraphQLErrorFilter>()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true)
    .RegisterDbContext<AppDbContext>(DbContextKind.Pooled)
    .AddQueryType(q => q.Name("Query"))
    .AddType<PostQuery>()
    .AddType<AuthorQuery>()
    .AddMutationType(x => x.Name("Mutation"))
    .AddType<PostMutation>()
    .AddType<AuthorMutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions()
    .AddProjections()
    .AddFiltering()
    .AddSorting();
builder.WebHost.UseUrls("http://localhost:5007");
//builder.Services.AddPooledDbContextFactory<AppDbContext>(options => options.UseSqlite("Data Source=helloapp.db"));
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql("server=172.16.100.102;user=root;password=1;database=graphqlapitesting;", new MySqlServerVersion(new Version(10, 1, 44))));
var app = builder.Build();
app.UseCors(corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin());
app.UseWebSockets();
// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
app.UseAuthentication();
app.MapGraphQL();    
app.Run();