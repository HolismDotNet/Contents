namespace Contents;

public class Part : IEntity, IParent
{
    public Part()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public long? ParentId { get; set; }

    public string PartTypes { get; set; }

    public dynamic RelatedItems { get; set; }
}
