namespace Contents;

public class PageController : Controller<Page, Page>
{
    public override ReadBusiness<Page> ReadBusiness => new PageBusiness();
    
    public override Business<Page, Page> Business => new PageBusiness();

    [HttpPost]
    public Page ToggleCommentAcceptance(long id)
    {
        var page = new PageBusiness().ToggleCommentAcceptance(id);
        return page;
    }

    [FileUploadChecker]
    [HttpPost]
    public Page SetImage(IFormFile file)
    {
        var pageId = Request.Query["pageId"];
        if (pageId.Count == 0)
        {
            throw new ClientException("Please provide pageId");
        }
        var bytes = file.OpenReadStream().GetBytes();
        var page = new PageBusiness().ChangeImage(pageId[0].ToLong(), bytes);
        return page;
    }
}
