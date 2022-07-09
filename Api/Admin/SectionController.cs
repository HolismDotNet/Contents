namespace Contents;

public class SectionController : Controller<Section, Section>
{
    public override ReadBusiness<Section> ReadBusiness => new SectionBusiness();

    public override Business<Section, Section> Business => new SectionBusiness();

    
}