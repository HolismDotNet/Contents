namespace Contents;

public class SectionContentBusiness : ClobBusiness<SectionContent, SectionContent>
{
    protected override Read<SectionContent> Read => Repository.SectionContent;

    protected override Write<SectionContent> Write => Repository.SectionContent;
}