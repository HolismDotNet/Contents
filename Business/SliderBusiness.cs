namespace Sliders;

public class SlideBusiness : Business<Slide, Slide>
{
    protected override Read<Slide> Read => Repository.Slide;

    protected override Write<Slide> Write => Repository.Slide;
}