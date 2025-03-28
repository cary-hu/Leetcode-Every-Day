/// <summary>
/// 20250328
/// https://leetcode.cn/problems/minimize-string-length/
/// </summary>
public class Solution
{
    public int MinimizedStringLength(string s)
    {
        return new HashSet<char>(s.ToCharArray()).Count;
    }
}