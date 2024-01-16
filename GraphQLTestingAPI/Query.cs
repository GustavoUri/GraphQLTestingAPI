using GraphQLTestingAPI.Entities;
using GraphQLTestingAPI.AppContext;
namespace GraphQLTestingAPI;

public class Query
{
    //[UseDbContext(typeof(AppDbContext))]
    public List<Post> GetPosts([Service] AppDbContext context) => context.Posts.ToList();
}