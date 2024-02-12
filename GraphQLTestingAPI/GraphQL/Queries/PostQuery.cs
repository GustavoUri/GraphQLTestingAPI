using GraphQLTestingAPI.Entities;
using GraphQLTestingDataLayer.AppContext;

namespace GraphQLTestingAPI;
[ExtendObjectType("Query")]
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