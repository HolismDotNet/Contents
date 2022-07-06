namespace Contents;

public class PageView : IEntity, IGuid, ISlug, IParent
{
    public PageView()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public Guid Guid { get; set; }

    public Guid HierarchyGuid { get; set; }

    public bool AcceptsComment { get; set; }

    public long HierarchyId { get; set; }

    public string Title { get; set; }

    public long? ParentId { get; set; }

    public string Description { get; set; }

    public string Slug { get; set; }

    public dynamic RelatedItems { get; set; }
}
