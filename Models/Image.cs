namespace Contents;

public class Image : IEntity, IKey
{
    public Image()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public string Title { get; set; }

    public Guid ImageGuid { get; set; }

    public string RecommendedDimensions { get; set; }

    public string RecommendedColorScheme { get; set; }

    public string Key { get; set; }

    public dynamic RelatedItems { get; set; }
}
