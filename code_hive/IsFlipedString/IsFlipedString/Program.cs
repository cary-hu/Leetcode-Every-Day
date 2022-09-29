/// <summary>
/// 20220929
/// https://leetcode.cn/problems/string-rotation-lcci/
/// </summary>
public class Solution
{
    public bool IsFlipedString(string s1, string s2)
    {
        if (s1.Length != s2.Length)
        {
            return false;
        }
        return (s1 + s1).Contains(s2);
    }
}