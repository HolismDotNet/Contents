namespace Contents;

public class PageContentBusiness : ClobBusiness<PageContent, PageContent>
{
    protected override Read<PageContent> Read => Repository.PageContent;

    protected override Write<PageContent> Write => Repository.PageContent;
}