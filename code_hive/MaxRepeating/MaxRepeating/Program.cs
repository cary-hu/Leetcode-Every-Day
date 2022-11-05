/// <summary>
/// 20221103
/// https://leetcode.cn/problems/maximum-repeating-substring/
/// </summary>
public class Solution
{
    public int MaxRepeating(string sequence, string word)
    {
        var s = word;
        int cnt = 0;
        while(sequence.Contains(s))
        {
            s += word;
            cnt++;
        }
        return cnt;
    }
}