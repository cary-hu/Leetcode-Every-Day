/// <summary>
/// 20221227
/// https://leetcode.cn/problems/minimum-moves-to-convert-string/
/// </summary>
public class Solution
{
    public int MinimumMoves(string s)
    {
        var n = s.Length;
        var i = 0;
        var res = 0;
        while (i < n)
        {
            if (s[i] == 'X')
            {
                i += 3;
                res++;
            }
            else
            {
                i++;
            }
        }
        return res;
    }
}