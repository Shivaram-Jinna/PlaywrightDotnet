using Newtonsoft.Json;
public static class ConfigLoader
{
    public static TestConfig LoadConfiguration()
    {
        string congifPath = "appsettings.json";
        if(!File.Exists(congifPath))
        {
            return new TestConfig();
        }
        var json = File.ReadAllText(congifPath);
        return JsonConvert.DeserializeObject<TestConfig>(json) ?? new TestConfig();
    }
}
