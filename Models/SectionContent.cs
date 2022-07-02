namespace Contents;

public class SectionContent : IEntity, IClob
{
    public SectionContent()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public string Content { get; set; }

    public dynamic RelatedItems { get; set; }
}
