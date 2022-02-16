namespace Contents;

public class TextBusiness : Business<Text, Text>
{
    protected override Read<Text> Read => Repository.Text;

    protected override Write<Text> Write => Repository.Text;

    public ExpandoObject GetKeyValues()
    {
        var items = GetAll();
        dynamic result = new ExpandoObject();
        foreach (var item in items)
        {
            ExpandoObjectExtensions.AddProperty(result, item.Key, item.Value);
        }
        return result;
    }
}