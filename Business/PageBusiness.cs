namespace Contents;

public class PageBusiness : Business<Page, Page>
{
    protected override Read<Page> Read => Repository.Page;

    protected override Write<Page> Write => Repository.Page;
}