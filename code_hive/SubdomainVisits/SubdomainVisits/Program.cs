/// <summary>
/// 20221005
/// https://leetcode.cn/problems/subdomain-visit-count/
/// </summary>
public class Solution
{
    private Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
    public IList<string> SubdomainVisits(string[] cpdomains)
    {
        foreach (var item in cpdomains)
        {
            HandleString(item);
        }
        var res = new List<string>();
        foreach (var item in keyValuePairs)
        {
            res.Add($"{item.Value} {item.Key}");
        }
        return res;
    }
    private void HandleString(string cpdomain)
    {
        var count = Convert.ToInt32(cpdomain.Split(" ")[0]);
        var domain = cpdomain.Split(" ")[1];
        var domainParts = domain.Split(".");
        for (int i = 0; i < domainParts.Length; i++)
        {
            var currentDomainParts = domainParts[i..];
            var currentDomain = string.Join(".", currentDomainParts);
            if (keyValuePairs.ContainsKey(currentDomain))
            {
                keyValuePairs[currentDomain] += count;
            } else
            {
                keyValuePairs.Add(currentDomain, count);
            }
        }
    }
}