namespace Sliders;

public class Slider : IEntity, IGuid, IKey
{
    public Slider()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public Guid Guid { get; set; }

    public string Title { get; set; }

    public string Key { get; set; }

    public dynamic RelatedItems { get; set; }
}
