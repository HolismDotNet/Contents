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

    [FileUploadChecker]
    [HttpPost]
    public Item SetImage(IFormFile file)
    {
        var itemId = Request.Query["itemId"];
        if (itemId.Count == 0)
        {
            throw new ClientException("Please provide itemId");
        }
        var bytes = file.OpenReadStream().GetBytes();
        var item = new ItemBusiness().ChangeImage(itemId[0].ToLong(), bytes);
        return item;
    }
}