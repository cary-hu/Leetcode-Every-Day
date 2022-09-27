/// <summary>
/// 20220927
/// https://leetcode.cn/problems/check-permutation-lcci/
/// </summary>
public class Solution
{
    public bool CheckPermutation(string s1, string s2)
    {
        var sum1 = 0;
        var sum2 = 0;
        if (s1.Length != s2.Length)
        {
            return false;
        }
        return string.Join("", s1.OrderBy(x => x)) == string.Join("", s2.OrderBy(x => x));
    }
}