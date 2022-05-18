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

    [HttpPost]
    public PageView ToggleCommentAcceptance(long id)
    {
        var page = new PageBusiness().ToggleCommentAcceptance(id);
        return page;
    }

    [FileUploadChecker]
    [HttpPost]
    public PageView SetImage(IFormFile file)
    {
        var pageId = Request.Query["pageId"];
        if (pageId.Count == 0)
        {
            throw new ClientException("Please provide pageId");
        }
        var bytes = file.OpenReadStream().GetBytes();
        var page = new PageBusiness().ChangeImage(pageId[0].ToLong(), bytes);
        return page;
    }
}
