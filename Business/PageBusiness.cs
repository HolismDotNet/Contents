namespace Contents;

public class PageBusiness : Business<PageView, Page>
{
    protected override Read<PageView> Read => Repository.PageView;

    protected override Write<Page> Write => Repository.Page;

    protected override void ModifyItemBeforeReturning(PageView item)
    {
        item.RelatedItems.ImageUrl = Storage.GetImageUrl(ContainerName, item.ImageGuid ?? Guid.Empty);
        base.ModifyItemBeforeReturning(item);
    }
}