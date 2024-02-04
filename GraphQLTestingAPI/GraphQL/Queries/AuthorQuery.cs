using GraphQLTestingAPI.DTO;
using GraphQLTestingAPI.Entities;
using GraphQLTestingAPI.Services;
using GraphQLTestingDataLayer.AppContext;
using Microsoft.EntityFrameworkCore;

namespace GraphQLTestingAPI.GraphQL.Queries;

[ExtendObjectType("Query")]
public class AuthorQuery
{
    /// <summary>
    /// Получить авторов
    /// </summary>
    //[UseDbContext(typeof(AppDbContext))]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<AuthorDTO> GetAuthors([Service] AuthorService service)
    {
        return service.GetAuthors();
    }
}