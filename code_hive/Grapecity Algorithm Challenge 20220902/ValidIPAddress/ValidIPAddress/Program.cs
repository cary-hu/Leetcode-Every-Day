using System.Text.RegularExpressions;
/// <summary>
/// 20220902
/// https://leetcode.cn/problems/validate-ip-address/
/// </summary>
public class Solution
{
    public string ValidIPAddress(string queryIP)
    {
        if (queryIP.Contains(".") && isValidIPV4IPAddress(queryIP))
            return "IPv4";
        else if (queryIP.Contains(":") && isValidIPV6IPAddress(queryIP))
            return "IPv6";
        return "Neither";

    }
    private bool isValidIPV4IPAddress(string queryIP)
    {
        var ips = queryIP.Split('.');
        if (ips.Length != 4)
        {
            return false;
        }
        foreach (var ip in ips)
        {
            if (ip.Length == 0 || ip.Length > 3)
            {
                return false;
            }
            if (ip.Length > 1 && ip[0] == '0')
            {
                return false;
            }
            if (!Regex.IsMatch(ip, @"^\d+$"))
            {
                return false;
            }
            if (int.Parse(ip) > 255)
            {
                return false;
            }

        }

        return true;
    }
    private bool isValidIPV6IPAddress(string queryIP)
    {
        var ips = queryIP.Split(':');
        if (ips.Length != 8)
        {
            return false;
        }
        foreach (var ip in ips)
        {
            if (ip.Length == 0 || ip.Length > 4)
            {
                return false;
            }
            if (!Regex.IsMatch(ip, @"^[0-9a-fA-F]+$"))
            {
                return false;
            }
        }
        return true;
    }
}