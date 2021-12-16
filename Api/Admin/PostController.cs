namespace Holism.Blog.AdminApi;

public class PostController : Controller<Post, Post>
{
    public override ReadBusiness<Post> ReadBusiness => new PostBusiness();
    
    public override Business<Post, Post> Business => new TicketBusiness();
}
