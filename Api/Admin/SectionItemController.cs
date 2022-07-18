namespace Contents;

public class SectionItemController : Controller<Item, Item>
{
    public override ReadBusiness<Item> ReadBusiness => new ItemBusiness();

    public override Business<Item, Item> Business => new ItemBusiness();

    [BindProperty(SupportsGet=true)]
    public long? SectionId { get; set; }

    public override Action<ListParameters> ListParametersAugmenter => listParameters => 
    {
        if (SectionId == null)
        {
            throw new ClientException("sectionId is not provided");
        }
        listParameters.AddFilter<Item>(i => i.SectionId, SectionId.Value);
    };

    [HttpPost]
    public Item SetPrimaryCta(long id)
    {
        var ctaText = HttpContext.ExtractProperty("PrimaryCtaText").ToString();;
        var ctaLink = HttpContext.ExtractProperty("PrimaryCtaLink").ToString();;
        var item = new ItemBusiness().SetPrimaryCta(id, ctaText, ctaLink);
        return item;
    }

    [HttpPost]
    public Item SetSecondaryCta(long id)
    {
        var ctaText = HttpContext.ExtractProperty("SecondaryCtaText").ToString();;
        var ctaLink = HttpContext.ExtractProperty("SecondaryCtaLink").ToString();;
        var item = new ItemBusiness().SetSeconaryCta(id, ctaText, ctaLink);
        return item;
    }

    [HttpPost]
    public Item SetIconSvg(long id)
    {
        var svg = HttpContext.GetBody().Result.Deserialize<string>();
        var item = new ItemBusiness().SetIconSvg(id, svg);
        return item;
    }
}