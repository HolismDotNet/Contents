namespace Contents;

public class ItemBusiness : Business<Item, Item>
{
    protected override Read<Item> Read => Repository.Item;

    protected override Write<Item> Write => Repository.Item;

    protected override void ModifyItemBeforeReturning(Item item)
    {
        item.RelatedItems.ImageUrl = Storage.GetImageUrl(ContainerName, item.ImageGuid ?? Guid.Empty);
        base.ModifyItemBeforeReturning(item);
    }

    public List<Item> GetItems(long sectionId)
    {
        var items = GetList(i => i.SectionId == sectionId);
        return items;
    }

    public Item SetPrimaryCta(long id, string ctaText, string ctaLink)
    {
        var item = Write.Get(id);
        item.PrimaryCtaText = ctaText;
        item.PrimaryCtaLink = ctaLink;
        Update(item);
        return Get(id);
    }

    public Item SetSeconaryCta(long id, string ctaText, string ctaLink)
    {
        var item = Write.Get(id);
        item.SecondaryCtaText = ctaText;
        item.SecondaryCtaLink = ctaLink;
        Update(item);
        return Get(id);
    }
}