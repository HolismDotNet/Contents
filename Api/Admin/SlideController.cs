namespace Holism.Slide.AdminApi;

public class SlideController : Controller<Post, Post>
{
    public override ReadBusiness<Post> ReadBusiness => new PostBusiness();
    
    public override Business<Post, Post> Business => new TicketBusiness();
}
