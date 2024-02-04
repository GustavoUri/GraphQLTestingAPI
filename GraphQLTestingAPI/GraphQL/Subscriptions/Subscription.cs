using GraphQLTestingAPI.Entities;

namespace GraphQLTestingAPI.GraphQL.Subscriptions;

public class Subscription
{
    [Subscribe]
    [Topic(nameof(PostMutation.AddPost))]
    public Post OnPublished([EventMessage] Post publishedPost)
    {
        return publishedPost;
    }
}