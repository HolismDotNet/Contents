namespace Slides;

public class SlidesContext : DatabaseContext
{
    public override string ConnectionStringName => "Slides";

    public DbSet<Slides.SlideImage> SlideImages { get; set; }

    public DbSet<Slides.Slide> Slides { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
