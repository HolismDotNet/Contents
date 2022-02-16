namespace Contents;

public class Text : IEntity, IKey
{
    public Text()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public string Title { get; set; }

    public string Value { get; set; }

    public string Key { get; set; }

    public dynamic RelatedItems { get; set; }
}
