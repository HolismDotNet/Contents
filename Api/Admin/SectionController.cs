namespace Contents;

public class SectionController : Controller<Section, Section>
{
    public override ReadBusiness<Section> ReadBusiness => new SectionBusiness();

    public override Business<Section, Section> Business => new SectionBusiness();

    [HttpPost]
    public Section ToggleItemsVariability(long id)
    {
        var section = new SectionBusiness().ToggleItemsVariability(id);
        return section;
    }

    [HttpPost]
    public Section ToggleActionsVariability(long id)
    {
        var section = new SectionBusiness().ToggleActionsVariability(id);
        return section;
    }

    [FileUploadChecker]
    [HttpPost]
    public Section SetImage(IFormFile file)
    {
        var sectionId = Request.Query["sectionId"];
        if (sectionId.Count == 0)
        {
            throw new ClientException("Please provide sectionId");
        }
        var bytes = file.OpenReadStream().GetBytes();
        var section = new SectionBusiness().ChangeImage(sectionId[0].ToLong(), bytes);
        return section;
    }
}