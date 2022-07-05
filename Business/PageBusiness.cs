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

    public PageView ToggleCommentAcceptance(long id)
    {
        var page = Write.Get(id);
        page.AcceptsComment = !page.AcceptsComment;
        Update(page);
        return Get(page.Id);
    }

    public PageView ChangeImage(long pageId, byte[] bytes)
    {
        var page = Get(pageId);
        var hierarchy = new HierarchyBusiness().GetByGuid(page.HierarchyGuid);
        if (hierarchy.ImageGuid.HasValue)
        {
            Storage.DeleteImage(ContainerName, hierarchy.ImageGuid.Value);
        }
        var fullHdImage = ImageHelper.MakeImageThumbnail(Resolution.FullHd, null, bytes);
        hierarchy.ImageGuid = Guid.NewGuid();
        Storage.UploadImage(fullHdImage.GetBytes(), hierarchy.ImageGuid.Value, ContainerName);
        new HierarchyBusiness().SetImage(hierarchy.Id, hierarchy.ImageGuid.Value);
        return Get(pageId);
    }
}