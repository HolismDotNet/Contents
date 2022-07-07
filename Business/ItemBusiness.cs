namespace Contents;

public class ItemBusiness : Business<Item, Item>
{
    protected override Read<Item> Read => Repository.Item;

    protected override Write<Item> Write => Repository.Item;

    protected override void ModifyItemBeforeReturning(Item item)
    {
        if (item.ImageGuid.HasValue)
        {
            item.RelatedItems.ImageUrl = Storage.GetImageUrl(ContainerName, item.ImageGuid.Value);
        }
        base.ModifyItemBeforeReturning(item);
    }

    public List<Item> GetItems(long sectionId)
    {
        var items = GetList(i => i.SectionId == sectionId);
        return items;
    }

    public Item SetCta(long id, string ctaText, string ctaLink)
    {
        var item = Write.Get(id);
        item.CtaText = ctaText;
        item.CtaLink = ctaLink;
        Update(item);
        return Get(id);
    }

    public Item ChangeImage(long itemId, byte[] bytes)
    {
        var item = Write.Get(itemId);
        if (item.ImageGuid.HasValue)
        {
            Storage.DeleteImage(ContainerName, item.ImageGuid.Value);
        }
        // var nhdImage = ImageHelper.MakeImageThumbnail(Resolution.Nhd, null, bytes);
        item.ImageGuid = Guid.NewGuid();
        Storage.UploadImage(bytes, item.ImageGuid.Value, ContainerName);
        Write.Update(item);
        return Get(itemId);
    }
}