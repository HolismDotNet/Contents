namespace Contents;

public class SectionController : Controller<Section, Section>
{
    public override ReadBusiness<Section> ReadBusiness => new SectionBusiness();

    public override Business<Section, Section> Business => new SectionBusiness();

    [HttpPost]
    public Section SetPrimaryCta(long id)
    {
        var ctaText = HttpContext.ExtractProperty("PrimaryCtaText").ToString();;
        var ctaLink = HttpContext.ExtractProperty("PrimaryCtaLink").ToString();;
        var section = new SectionBusiness().SetPrimaryCta(id, ctaText, ctaLink);
        return section;
    }

    [HttpPost]
    public Section SetSecondaryCta(long id)
    {
        var ctaText = HttpContext.ExtractProperty("SecondaryCtaText").ToString();;
        var ctaLink = HttpContext.ExtractProperty("SecondaryCtaLink").ToString();;
        var section = new SectionBusiness().SetSeconaryCta(id, ctaText, ctaLink);
        return section;
    }
    
}