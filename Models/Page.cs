namespace Contents;

public class Page : IEntity, IGuid
{
    public Page()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public Guid Guid { get; set; }

    public Guid HierarchyGuid { get; set; }

    public Guid? ImageGuid { get; set; }

    public bool AcceptsComment { get; set; }

    public dynamic RelatedItems { get; set; }
}
