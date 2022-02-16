namespace Contents;

public class Item : IEntity, IOrder
{
    public Item()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public long SectionId { get; set; }

    public Guid? ImageGuid { get; set; }

    public Guid? AvatarGuid { get; set; }

    public string Title { get; set; }

    public string Subtitle { get; set; }

    public string Summary { get; set; }

    public string Url { get; set; }

    public string ExtraJson { get; set; }

    public long Order { get; set; }

    public dynamic RelatedItems { get; set; }
}
