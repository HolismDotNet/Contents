namespace Contents;

public class Repository
{
    public static Write<Contents.Image> Image
    {
        get
        {
            return new Write<Contents.Image>(new ContentsContext());
        }
    }

    public static Write<Contents.Item> Item
    {
        get
        {
            return new Write<Contents.Item>(new ContentsContext());
        }
    }

    public static Write<Contents.PageContent> PageContent
    {
        get
        {
            return new Write<Contents.PageContent>(new ContentsContext());
        }
    }

    public static Write<Contents.Page> Page
    {
        get
        {
            return new Write<Contents.Page>(new ContentsContext());
        }
    }

    public static Write<Contents.PageView> PageView
    {
        get
        {
            return new Write<Contents.PageView>(new ContentsContext());
        }
    }

    public static Write<Contents.SectionContent> SectionContent
    {
        get
        {
            return new Write<Contents.SectionContent>(new ContentsContext());
        }
    }

    public static Write<Contents.Section> Section
    {
        get
        {
            return new Write<Contents.Section>(new ContentsContext());
        }
    }

    public static Write<Contents.Text> Text
    {
        get
        {
            return new Write<Contents.Text>(new ContentsContext());
        }
    }
}
