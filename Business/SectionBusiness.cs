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
            var section = GetByKey(key);
            if (section != null)
            {
                sections.Add(section);
            }
        }
        var result = sections.ToDictionary(i => i.Key, i => i);
        return result;
    }

    public Section ToggleItemsVariability(long id)
    {
        var section = Write.Get(id);
        section.VariableItems = section.VariableItems == null ? true : !section.VariableItems;
        Update(section);
        return Get(section.Id);
    }

    public Section ToggleActionsVariability(long id)
    {
        var section = Write.Get(id);
        section.VariableActions = section.VariableActions == null ? true : !section.VariableActions;
        Update(section);
        return Get(section.Id);
    }
}