namespace Contents;

public class PageContentController : Controller<PageContent, PageContent>
{
    public override ReadBusiness<PageContent> ReadBusiness => new PageContentBusiness();

    public override Business<PageContent, PageContent> Business => new PageContentBusiness();
}