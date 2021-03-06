namespace Contents;

public class Section : IEntity, IGuid, IKey, IOrder
{
    public Section()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public Guid Guid { get; set; }

    public string Name { get; set; }

    public string Supertitle { get; set; }

    public string Title { get; set; }

    public string Subtitle { get; set; }

    public string Description { get; set; }

    public Guid? ImageGuid { get; set; }

    public string PrimaryCtaText { get; set; }

    public string PrimaryCtaLink { get; set; }

    public string SecondaryCtaText { get; set; }

    public string SecondaryCtaLink { get; set; }

    public string Json { get; set; }

    public string Key { get; set; }

    public long Order { get; set; }

    public dynamic RelatedItems { get; set; }
}
