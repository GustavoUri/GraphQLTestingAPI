using GraphQLTestingAPI.AppContext;
using GraphQLTestingAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLTestingAPI;
[ExtendObjectType("query")]
public class AuthorQuery
{
    /// <summary>
    /// Получить авторов
    /// </summary>
    //[UseDbContext(typeof(AppDbContext))]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public List<Author> GetAuthors(AppDbContext context) => context.Authors.Include(x => x.Posts).ToList();
}