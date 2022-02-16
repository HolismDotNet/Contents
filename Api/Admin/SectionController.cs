namespace Contents;

public class SectionController : ReadController<Section>
{
    public override ReadBusiness<Section> ReadBusiness => new SectionBusiness();
}