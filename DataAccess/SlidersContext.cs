namespace Sliders;

public class SlidersContext : DatabaseContext
{
    public override string ConnectionStringName => "Sliders";

    public DbSet<Sliders.Slider> Sliders { get; set; }

    public DbSet<Sliders.Slide> Slides { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
