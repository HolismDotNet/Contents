namespace Sliders;

public class SlideBusiness : Business<Slide, Slide>
{
    protected override ReadRepository<Slide> ReadRepository => Repository.Slide;

    protected override Repository<Slide> WriteRepository => Repository.Slide;
}