namespace Contents;

public class PageBusiness : Business<Page, Page>
{
    protected override Read<Page> Read => Repository.Page;

    protected override Write<Page> Write => Repository.Page;

    public Page ToggleCommentAcceptance(long id)
    {
        var page = Write.Get(id);
        page.AcceptsComment = !page.AcceptsComment;
        Update(page);
        return Get(page.Id);
    }

    public Page ChangeImage(long pageId, byte[] bytes)
    {
        var page = Write.Get(pageId);
        if (page.ImageGuid.HasValue)
        {
            Storage.DeleteImage(ContainerName, page.ImageGuid.Value);
        }
        var fullHdImage = ImageHelper.MakeImageThumbnail(Resolution.FullHd, null, bytes);
        page.ImageGuid = Guid.NewGuid();
        Storage.UploadImage(fullHdImage.GetBytes(), page.ImageGuid.Value, ContainerName);
        Write.Update(page);
        return Get(pageId);
    }
}