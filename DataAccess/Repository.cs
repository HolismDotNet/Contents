namespace Holism.Slides.DataAccess;

public class Repository
{
    public static Repository<Image> Image
    {
        get
        {
            return new Repository<Image>(new SlidesContext());
        }
    }    public static Repository<Slide> Slide
    {
        get
        {
            return new Repository<Slide>(new SlidesContext());
        }
    }


}
