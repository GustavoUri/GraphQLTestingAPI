using GraphQLTestingAPI.Entities;
using GraphQLTestingAPI.AppContext;
using Microsoft.EntityFrameworkCore;

namespace GraphQLTestingAPI;
[ExtendObjectType("query")]
public class PostQuery
{
    /// <summary>
    /// Получить посты
    /// </summary>
    //[UseDbContext(typeof(AppDbContext))]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public List<Post> GetPosts(AppDbContext context) => context.Posts.ToList();
}