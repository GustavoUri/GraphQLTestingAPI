namespace GraphQLTestingAPI.Entities;

public class Author
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Post>? Posts { get; set; }
}