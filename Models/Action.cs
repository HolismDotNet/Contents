namespace Contents;

public class Action : IEntity
{
    public Action()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public long SectionId { get; set; }

    public string CtaText { get; set; }

    public string CtaLink { get; set; }

    public dynamic RelatedItems { get; set; }
}
