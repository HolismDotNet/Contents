namespace Contents;

public class ItemBusiness : Business<Item, Item>
{
    protected override Read<Item> Read => Repository.Item;

    protected override Write<Item> Write => Repository.Item;

    protected override void ModifyItemBeforeReturning(Item item)
    {
        item.RelatedItems.ImageUrl = Storage.GetImageUrl(ContainerName, item.ImageGuid ?? Guid.Empty);
        item.RelatedItems.AvatarUrl = Storage.GetImageUrl(ContainerName, item.AvatarGuid ?? Guid.Empty);
        base.ModifyItemBeforeReturning(item);
    }

    public List<Item> GetItems(long sectionId)
    {
        var items = GetList(i => i.SectionId == sectionId);
        foreach(var item in items)
        {
            item.RelatedItems.Tags = new List<Tag>();
        }
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

    public Item SetIconSvg(long id, string svg)
    {
        var item = Get(id);
        item.IconSvg = svg;
        item = Update(item);
        return item;
    }
}