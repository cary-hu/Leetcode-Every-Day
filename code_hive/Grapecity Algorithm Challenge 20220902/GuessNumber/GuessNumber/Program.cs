/// <summary>
/// 20220902
/// https://leetcode.cn/problems/guess-number-higher-or-lower/
/// </summary>
public class Solution : GuessGame
{
    public int GuessNumber(int n)
    {
        int l = 1;
        int r = n;
        while (l < r)
        {
            var mid = l + (r - l) / 2;
            if (guess(mid) <= 0)
            {
                r = mid;
            }
            else
            {
                l = mid + 1;
            }
        }
        return l;
    }
}