namespace Slides;

public class Repository
{
    public static Repository<Slides.SlideImage> SlideImage
    {
        get
        {
            return new Repository<Slides.SlideImage>(new SlidesContext());
        }
    }

    public static Repository<Slides.Slide> Slide
    {
        get
        {
            return new Repository<Slides.Slide>(new SlidesContext());
        }
    }
}
