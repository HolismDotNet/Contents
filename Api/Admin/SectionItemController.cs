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
    public Item SetCta(long id)
    {
        var ctaText = HttpContext.ExtractProperty("CtaText").ToString();;
        var ctaLink = HttpContext.ExtractProperty("CtaLink").ToString();;
        var item = new ItemBusiness().SetCta(id, ctaText, ctaLink);
        return item;
    }
}