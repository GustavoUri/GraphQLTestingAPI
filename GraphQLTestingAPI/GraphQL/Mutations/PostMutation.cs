using GraphQLTestingAPI.AppContext;
using GraphQLTestingAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLTestingAPI;

[ExtendObjectType("Mutation")]
public class PostMutation
{
    public async Task<Post> AddPost(AppDbContext context, string title, string content, Guid authorId)
    {
        var author = context.Authors.Include(x => x.Posts).FirstOrDefault(x => x.Id == authorId);
        if (author == null)
            throw new Exception("Нет автора с таким id");
        var newPost = new Post()
        {
            Title = title,
            Content = content
        };
        if (author.Posts == null)
        {
            author.Posts = new List<Post>()
            {
                newPost
            };
        }
        else
        {
            author.Posts.Add(newPost);
        }

        context.Posts.Add(newPost);
        await context.SaveChangesAsync();
        return newPost;
    }

    public async Task<Post> UpdatePost(AppDbContext context, Guid postId, string? title, string? content,
        Guid? authorId)
    {
        var post = context.Posts.FirstOrDefault(x => x.Id == postId);
        if (post == null)
            throw new Exception("Нет поста с таким id");

        if (authorId != null)
        {
            var author = context.Authors.Include(x => x.Posts).FirstOrDefault(x => x.Id == authorId);
            if (author == null)
                throw new Exception("Нет автора с таким id");
            if (author.Posts == null)
                author.Posts = new List<Post>() { post };
            else
                author.Posts.Add(post);

            author.Posts.Add(post);
        }

        if (title != null)
            post.Title = title;
        if (content != null)
            post.Content = content;

        await context.SaveChangesAsync();
        return post;
    }

    public Task<Post> DeletePost(AppDbContext context, Guid postId)
    {
        var post = context.Posts.FirstOrDefault(x => x.Id == postId);
        if (post == null)
        {
            throw new Exception("Нет поста с таким id");
        }

        context.Posts.Remove(post);
        context.SaveChangesAsync();
        return Task.FromResult(post);
    }
}