using System.Text;

public static class TestUtils
{
    // Random username generator
    public static string GenerateRandomUsername(int length = 6)
    {
        string prefix = "User";
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        var randomString = new StringBuilder(length);
        for (int i = 0; i < length; i++)
        {
            randomString.Append(chars[random.Next(chars.Length)]);
        }
        return $"{prefix}{randomString}";
    }

    // Random email generator
    public static string GenerateRandomEmail()
    {
        return $"user{GenerateRandomUsername()}@example.com";
    }
}
