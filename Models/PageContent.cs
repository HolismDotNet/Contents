namespace Contents;

public class PageContent : IEntity, IClob
{
    public PageContent()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public string Content { get; set; }

    public dynamic RelatedItems { get; set; }
}
