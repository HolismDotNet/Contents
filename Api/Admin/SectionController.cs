namespace Contents;

public class SectionController : Controller<Section, Section>
{
    public override ReadBusiness<Section> ReadBusiness => new SectionBusiness();

    public override Business<Section, Section> Business => new SectionBusiness();

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