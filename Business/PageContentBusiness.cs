namespace Contents;

public class PageContentBusiness : Business<PageContent, PageContent>
{
    protected override Read<PageContent> Read => Repository.PageContent;

    protected override Write<PageContent> Write => Repository.PageContent;

    public override PageContent Get(long id)
    {
        var pageContent = Read.Get(id);
        if (pageContent == null)
        {
            pageContent = new PageContent();
            pageContent.Id = id;
            pageContent.Content = "[]";
            Create(pageContent);
        }
        return pageContent;
    }
}