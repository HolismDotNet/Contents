namespace Holism.Slides.Models;

public class SlideImage : IEntity
{
    public SlideImage()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public string Path { get; set; }

    public dynamic RelatedItems { get; set; }
}
