namespace Holism.Slides.DataAccess;

public class SlidesContext : DatabaseContext
{
    public override string ConnectionStringName => "Slides";

    public DbSet<SlideImage> SlideImages { get; set; }

    public DbSet<Slide> Slides { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
