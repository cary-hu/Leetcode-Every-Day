/// <summary>
/// 20221108
/// https://leetcode.cn/problems/count-the-number-of-consistent-strings/
/// </summary>
public class Solution
{
    public int CountConsistentStrings(string allowed, string[] words)
    {
        int ans = words.Length;
        for (int i = 0; i < words.Length; i++)
        {
            foreach (char c in words[i].ToArray())
            {
                if (!allowed.Contains(c))
                {
                    ans--;
                    break;
                }
            }
        }
        return ans;
    }
}