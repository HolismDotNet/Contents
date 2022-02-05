namespace Sliders;

public class Slide : IEntity, IOrder
{
    public Slide()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public long SliderId { get; set; }

    public Guid? ImageGuid { get; set; }

    public Guid? AvatarGuid { get; set; }

    public string Title { get; set; }

    public string Subtitle { get; set; }

    public string Summary { get; set; }

    public string Url { get; set; }

    public string ExtraJson { get; set; }

    public string Order { get; set; }

    public dynamic RelatedItems { get; set; }
}
