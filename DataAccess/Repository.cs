namespace Sliders;

public class Repository
{
    public static Write<Sliders.Slider> Slider
    {
        get
        {
            return new Write<Sliders.Slider>(new SlidersContext());
        }
    }

    public static Write<Sliders.Slide> Slide
    {
        get
        {
            return new Write<Sliders.Slide>(new SlidersContext());
        }
    }
}
