namespace Sliders;

public class SliderController : ReadController<Slider>
{
    public override ReadBusiness<Slider> ReadBusiness => new SliderBusiness();
}