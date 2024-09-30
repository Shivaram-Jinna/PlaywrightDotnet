using Newtonsoft.Json;
public static class ConfigLoader
{
    public static TestConfig LoadConfiguration()
    {
        var json = File.ReadAllText("appsettings.json");
        return JsonConvert.DeserializeObject<TestConfig>(json);
    }
}
