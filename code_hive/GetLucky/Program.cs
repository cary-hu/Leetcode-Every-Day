/// <summary>
/// 20221215
/// https://leetcode.cn/problems/sum-of-digits-of-string-after-convert/
/// </summary>
public class Solution
{
    public int GetLucky(string s, int k)
    {
        var originNumber = ConvertChar(s);
        var res = originNumber;
        while (k > 0)
        {
            k--;
            res = ConvertNumber(res);
        }
        return Convert.ToInt32(res);
    }
    private string ConvertChar(string s)
    {
        var res = "";
        foreach (var charItem in s)
        {
            res += charItem - 'a' + 1;
        }
        return res;
    }
    private string ConvertNumber(string s)
    {
        var res = 0;
        foreach (var charItem in s)
        {
            res += charItem - '0';
        }
        return res.ToString();
    }
}