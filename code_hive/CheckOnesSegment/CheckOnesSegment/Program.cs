/// <summary>
/// 20221003
/// https://leetcode.cn/problems/check-if-binary-string-has-at-most-one-segment-of-ones/
/// </summary>
public class Solution
{
    public bool CheckOnesSegment(string s)
    {
        return !s.Contains("01");
    }
}