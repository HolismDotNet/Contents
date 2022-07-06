namespace Contents;

public class SectionContentController : Controller<SectionContent, SectionContent>
{
    public override ReadBusiness<SectionContent> ReadBusiness => new SectionContentBusiness();

    public override Business<SectionContent, SectionContent> Business => new SectionContentBusiness();
}