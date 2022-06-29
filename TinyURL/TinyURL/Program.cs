/// <summary>
/// 20220629
/// https://leetcode.cn/problems/encode-and-decode-tinyurl/
/// </summary>
public class Codec
{
    private string baseUrl = "http://tinyurl.com/";
    private Dictionary<string, string> dict = new Dictionary<string, string>();
    
    // Encodes a URL to a shortened URL
    public string encode(string longUrl)
    {
        if(dict.ContainsKey(longUrl))
        {
            return $"{baseUrl}{dict[longUrl]}";
        }
        var shortUrl = Guid.NewGuid().ToString().Substring(0, 6);
        dict.Add(longUrl, shortUrl);
        return $"{baseUrl}{shortUrl}";
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl)
    {
        return dict.FirstOrDefault(x => x.Value == shortUrl.Replace(baseUrl, "")).Key;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(url));