namespace Sliders;

public class Repository
{
    public static Repository<Sliders.Slider> Slider
    {
        get
        {
            return new Repository<Sliders.Slider>(new SlidersContext());
        }
    }

    public static Repository<Sliders.Slide> Slide
    {
        get
        {
            return new Repository<Sliders.Slide>(new SlidersContext());
        }
    }
}
