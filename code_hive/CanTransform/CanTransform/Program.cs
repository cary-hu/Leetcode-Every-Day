/// <summary>
/// 20221002
/// https://leetcode.cn/problems/swap-adjacent-in-lr-string/
/// </summary>
public class Solution
{
    public bool CanTransform(string start, string end)
    {
        if (start.Replace("X", "") != end.Replace("X", ""))
        {
            return false;
        }
        int strSize = start.Length, i = 0, j = 0;
        while (i < strSize && j < strSize)
        {
            while (i < strSize && start[i] == 'X')
            {
                ++i;
            }
            while (j < strSize && end[j] == 'X')
            {
                ++j;
            }
            if (start[i] != end[j])
            {
                return false;
            }
            if ((start[i] == 'L' && i < j) || (end[j] == 'R' && i > j))
            {
                return false;
            }
            ++i;
            ++j;
        }
        return true;
    }
}