namespace Contents;

public class SectionBusiness : Business<Section, Section>
{
    protected override Read<Section> Read => Repository.Section;

    protected override Write<Section> Write => Repository.Section;

    protected override void ModifyItemBeforeReturning(Section item)
    {
        item.RelatedItems.ImageUrl = Storage.GetImageUrl(ContainerName, item.ImageGuid ?? Guid.Empty);
        base.ModifyItemBeforeReturning(item);
    }

    public override Section GetByKey(string key)
    {
        var section = base.GetByKey(key);
        if (section == null)
        {
            return null;
        }
        section.RelatedItems.Items = new ItemBusiness().GetItems(section.Id);
        section.RelatedItems.Content = new SectionContentBusiness().Get(section.Id);
        return section;
    }

    public List<Section> GetByKeys(params string[] keys)
    {
        var sections = new List<Section>();
        foreach (var key in keys)
        {
            var section = Cache.Get(key);
            if (section != null)
            {
                sections.Add((Section)section);
            }
            else
            {
                Logger.LogWarning($"Section {key} is not cached. It might not exist in the database");
                var dbSection = GetByKey(key);
                if (dbSection != null)
                {
                    sections.Add(dbSection);
                }
            }
        }
        return sections;
    }

    public Dictionary<string, Section> LoadCache()
    {
        var keys = GetKeys();
        var sections = new List<Section>();
        foreach (var key in keys)
        {
            var section = GetByKey(key);
            if (section != null)
            {
                sections.Add(section);
            }
        }
        var result = sections.ToDictionary(i => i.Key, i => i);
        return result;
    }
}