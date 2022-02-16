namespace Contents;

public class TextBusiness : Business<Text, Text>
{
    protected override Read<Text> Read => Repository.Text;

    protected override Write<Text> Write => Repository.Text;
}