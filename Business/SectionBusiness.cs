namespace Contents;

public class SectionBusiness : Business<Section, Section>
{
    protected override Read<Section> Read => Repository.Section;

    protected override Write<Section> Write => Repository.Section;

    protected override void ModifyItemBeforeReturning(Section item)
    {
        item.RelatedItems.ImageUrl = Storage.GetImageUrl(ContainerName, item.ImageGuid ?? Guid.Empty);
        item.RelatedItems.Configs = new EntityConfigBusiness().GetConfigsObject(EntityType, item.Guid);
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

    public List<dynamic> GetAllSections()
    {
        List<string> keys = (List<string>)Cache.Get("AllSectionKeys");
        if (keys == null) 
        {
            keys = GetKeys();
        }
        var sections = GetByKeys(keys.ToArray());
        return sections;
    }

    public List<dynamic> GetByKeys(params string[] keys)
    {
        var sections = new List<dynamic>();
        foreach (var key in keys)
        {
            var section = Cache.Get(key);
            if (section != null)
            {
                sections.Add(section);
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

    public Section SetPrimaryCta(long id, string ctaText, string ctaLink)
    {
        var section = Write.Get(id);
        section.PrimaryCtaText = ctaText;
        section.PrimaryCtaLink = ctaLink;
        Update(section);
        return Get(id);
    }

    public Section SetSeconaryCta(long id, string ctaText, string ctaLink)
    {
        var section = Write.Get(id);
        section.SecondaryCtaText = ctaText;
        section.SecondaryCtaLink = ctaLink;
        Update(section);
        return Get(id);
    }

    public Dictionary<string, dynamic> LoadCache()
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
        var result = sections.ToDictionary(i => i.Key, i => Minify(i));
        result.Add("AllSectionKeys", keys);
        return result;
    }

    private object Minify(Section section)
    {
        dynamic minified = new ExpandoObject();
        var configs = section.RelatedItems.Configs;
        MinifySection(section, minified);
        if (configs.HasItems)
        {
            minified.Items = MinifyItems(section, minified);
        }
        return minified;
    }

    private dynamic MinifyItems(Section section, dynamic minified)
    {
        var items = section.RelatedItems.Items;
        var configs = section.RelatedItems.Configs;
        var minifiedItems = new List<dynamic>();
        foreach (var item in items)
        {
            minifiedItems.Add(MinifyItem(item, configs));
        }
        return minifiedItems;
    }

    private dynamic MinifyItem(Item item, dynamic configs)
    {
        dynamic minified = new ExpandoObject();
        minified.Id = item.Id;
        if (configs.ItemsHaveSupertitle == true)
        {
            minified.Supertitle = item.Supertitle;
        }
        if (configs.ItemsHaveTitle == true)
        {
            minified.Title = item.Title;
        }
        if (configs.ItemsHaveSubtitle == true)
        {
            minified.Subtitle = item.Subtitle;
        }
        if (configs.ItemsHaveSummary == true)
        {
            minified.Summary = item.Summary;
        }
        if (configs.ItemsHaveImage == true)
        {
            minified.Image = item.RelatedItems.ImageUrl;
        }
        if (configs.ItemsHaveAvatar == true)
        {
            minified.Avatar = item.RelatedItems.AvatarUrl;
        }
        if (configs.ItemsHaveSvgIcon == true)
        {
            minified.IconSvg = item.IconSvg;
        }
        if (configs.ItemsHavePrimaryCta == true)
        {
            minified.PrimaryCtaText = item.PrimaryCtaText;
            minified.PrimaryCtaLink = item.PrimaryCtaLink;
        }
        if (configs.ItemsHaveSecondaryCta == true)
        {
            minified.SecondaryCtaText = item.SecondaryCtaText;
            minified.SecondaryCtaLink = item.SecondaryCtaLink;
        }
        if (configs.ItemsHaveTags == true)
        {
            var tags = item.RelatedItems.Tags as List<Tag>;
            minified.Tags = tags.Select(i => new { i.Id, i.Name });
        }
        return minified;
    }

    private void MinifySection(Section section, dynamic minified)
    {
        var configs = section.RelatedItems.Configs;
        minified.Id = section.Id;
        minified.Key = section.Key;
        if (configs.HasSupertitle == true)
        {
            minified.Supertitle = section.Supertitle;
        }
        if (configs.HasTitle == true)
        {
            minified.Title = section.Title;
        }
        if (configs.HasSubtitle == true)
        {
            minified.Subtitle = section.Subtitle;
        }
        if (configs.HasDescription == true)
        {
            minified.Description = section.Description;
        }
        if (configs.HasImage == true)
        {
            minified.ImageUrl = section.RelatedItems.ImageUrl;
        }
        if (configs.HasContent == true)
        {
            minified.Content = section.RelatedItems.Content.Content;
        }
        if (configs.HasPrimaryCta == true)
        {
            minified.PrimaryCtaText = section.PrimaryCtaText;
            minified.PrimaryCtaLink = section.PrimaryCtaLink;
        }
        if (configs.HasSecondaryCta == true)
        {
            minified.SecondaryCtaText = section.SecondaryCtaText;
            minified.SecondaryCtaLink = section.SecondaryCtaLink;
        }
        if (configs.ItemsHaveTags == true)
        {
            var items = section.RelatedItems.Items as List<Item>;
            var tags = items
            .SelectMany(i => (List<Tag>)i.RelatedItems.Tags)
            .ToList();
            var uniqueTags = new Dictionary<long, Tag>();
            foreach (var tag in tags)
            {
                if (uniqueTags.ContainsKey(tag.Id))
                {
                    continue;
                }
                uniqueTags.Add(tag.Id, tag);
            }
            minified.Tags = uniqueTags
            .Select(i => new { Id = i.Key, Name = i.Value.Name })
            .ToList();
        }
    }
}