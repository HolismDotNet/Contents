namespace Contents;

public class ContentsContext : DatabaseContext
{
    public override string ConnectionStringName => "Contents";

    public DbSet<Contents.Action> Actions { get; set; }

    public DbSet<Contents.Image> Images { get; set; }

    public DbSet<Contents.Item> Items { get; set; }

    public DbSet<Contents.PageContent> PageContents { get; set; }

    public DbSet<Contents.Page> Pages { get; set; }

    public DbSet<Contents.Section> Sections { get; set; }

    public DbSet<Contents.Text> Texts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
