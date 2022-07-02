namespace Contents;

public class SectionBusiness : Business<Section, Section>
{
    protected override Read<Section> Read => Repository.Section;

    protected override Write<Section> Write => Repository.Section;

    protected override void ModifyItemBeforeReturning(Section item)
    {
        item.RelatedItems.ImageUrl = Storage.GetImageUrl(ContainerName, item.ImageGuid ?? Guid.Empty);
    }

    public override Section GetByKey(string key)
    {
        if (Cache.Has(key))
        {
            return (Section)Cache.Get(key);
        }
        var section = base.GetByKey(key);
        if (section == null)
        {
            return null;
        }
        Augment(section);
        return section;
    }

    public void Augment(Section section)
    {
        section.RelatedItems.Items = new ItemBusiness().GetItems(section.Id);
        section.RelatedItems.Content = new SectionContentBusiness().Get(section.Id);
    }

    public List<Section> GetByKeys(params string[] keys)
    {
        var sections = new List<Section>();
        foreach (var key in keys)
        {
            var section = GetByKey(key);
            if (section != null)
            {
                sections.Add(section);
            }
        }
        return sections;
    }

    public Section ChangeImage(long sectionId, byte[] bytes)
    {
        var section = Write.Get(sectionId);
        if (section.ImageGuid.HasValue)
        {
            Storage.DeleteImage(ContainerName, section.ImageGuid.Value);
        }
        var nhdImage = ImageHelper.MakeImageThumbnail(Resolution.Nhd, null, bytes);
        section.ImageGuid = Guid.NewGuid();
        Storage.UploadImage(nhdImage.GetBytes(), section.ImageGuid.Value, ContainerName);
        Write.Update(section);
        return Get(sectionId);
    }

    public Dictionary<string, Section> LoadCache()
    {
        var keys = GetKeys();
        var sections = new List<Section>();
        foreach (var key in keys)
        {
            var section = base.GetByKey(key);
            if (section != null)
            {
                sections.Add(section);
            }
        }
        var result = sections.ToDictionary(i => i.Key, i => i);
        return result;
    }
}