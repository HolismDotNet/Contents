namespace Contents;

public class SectionBusiness : Business<Section, Section>
{
    protected override Read<Section> Read => Repository.Section;

    protected override Write<Section> Write => Repository.Section;
}