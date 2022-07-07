namespace Contents;

public class ItemBusiness : Business<Item, Item>
{
    protected override Read<Item> Read => Repository.Item;

    protected override Write<Item> Write => Repository.Item;

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
}