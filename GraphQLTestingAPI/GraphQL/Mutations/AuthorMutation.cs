using GraphQLTestingAPI.Entities;
using GraphQLTestingDataLayer.AppContext;

namespace GraphQLTestingAPI;

[ExtendObjectType("Mutation")]
public class AuthorMutation
{
    public async Task<Author> AddAuthor(AppDbContext context, string name, string email)
    {
        var author = new Author()
        {
            Name = name,
            Email = email,
            Posts = null
        };
        context.Authors.Add(author);
        await context.SaveChangesAsync();
        return author;
    }

    public async Task<Author> UpdateAuthor(AppDbContext context, Guid authorId, string? name, string? email)
    {
        var author = context.Authors.FirstOrDefault(x => x.Id == authorId);
        if (author == null)
            throw new Exception("Нет автора с таким id");
        if (email != null)
            author.Email = email;
        if (name != null)
            author.Name = name;
        await context.SaveChangesAsync();
        return author;
    }

    public Task<Author> DeleteAuthor(AppDbContext context, Guid authorId)
    {
        var author = context.Authors.FirstOrDefault(x => x.Id == authorId);
        if (author == null)
            throw new Exception("Нет автора с таким id");

        context.Authors.Remove(author);
        context.SaveChangesAsync();
        return Task.FromResult(author);
    }
}