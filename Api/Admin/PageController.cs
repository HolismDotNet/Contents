namespace Contents;

public class PageController : Controller<PageView, Page>
{
    public override ReadBusiness<PageView> ReadBusiness => new PageBusiness();
    
    public override Business<PageView, Page> Business => new PageBusiness();

    public override Action<Page, UpsertMode> PreUpsertion => (page, upsertMode) =>
    {
        var uiHierarchy = Extract<Hierarchy>();
        if (upsertMode == UpsertMode.Creation)
        {
            uiHierarchy.EntityTypeGuid = new EntityTypeBusiness().GetGuid(new PageBusiness().EntityType);
            new HierarchyBusiness().Create(uiHierarchy);
            page.HierarchyGuid = uiHierarchy.Guid;
        }
        else
        {
            page = new PageBusiness().Get(page.Id).CastTo<Page>();
            var dbHierarchy = new HierarchyBusiness().GetByGuid(page.HierarchyGuid);
            dbHierarchy.Title = uiHierarchy.Title;
            dbHierarchy.Slug = uiHierarchy.Slug;
            dbHierarchy.Description = uiHierarchy.Description;
            new HierarchyBusiness().Update(dbHierarchy.CastTo<Hierarchy>());
        }
    };
}
