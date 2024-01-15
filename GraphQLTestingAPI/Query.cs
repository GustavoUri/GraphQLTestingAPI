namespace GraphQLTestingAPI;

public class Query
{
    public string Hello(string name = "World") => $"Hello, {name}!";
}