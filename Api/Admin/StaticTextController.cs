namespace Contents;

public class StaticTextController : Controller<Text, Text>
{
    public override ReadBusiness<Text> ReadBusiness => new TextBusiness();

    public override Business<Text, Text> Business => new TextBusiness();
}