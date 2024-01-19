using GraphQLTestingAPI.AppContext;
using GraphQLTestingAPI.DTO;

namespace GraphQLTestingAPI.Services;

public class AuthorService
{
    private readonly AppDbContext _context;

    public AuthorService(AppDbContext context)
    {
        _context = context;
    }
    
    public IQueryable<AuthorDTO> GetAuthors()
    {
        var authors = _context.Authors.Select(x => new AuthorDTO
        {
            Id = x.Id,
            Name = x.Name
        });
        return authors;
    }
}