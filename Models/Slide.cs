namespace Slides;

public class Slide : IEntity
{
    public Slide()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public string Title { get; set; }

    public long ImageId { get; set; }

    public dynamic RelatedItems { get; set; }
}
