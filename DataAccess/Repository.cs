namespace Holism.Slides.DataAccess;

public class Repository
{
    public static Repository<SlideImage> SlideImage
    {
        get
        {
            return new Repository<SlideImage>(new SlidesContext());
        }
    }    public static Repository<Slide> Slide
    {
        get
        {
            return new Repository<Slide>(new SlidesContext());
        }
    }


}
