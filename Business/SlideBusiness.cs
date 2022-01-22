using Holism.Slides.DataAccess;

namespace Holism.Slides.Business;

public class SlideBusiness : Business<Slide, Slide>
{
    protected override ReadRepository<Slide> ReadRepository => Repository.Slide;

    protected override Repository<Slide> WriteRepository => Repository.Slide;
}