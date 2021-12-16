namespace Holism.Slides.Models;

public class Image : IEntity
{
    public Image()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public string Path { get; set; }

    public dynamic RelatedItems { get; set; }
}
