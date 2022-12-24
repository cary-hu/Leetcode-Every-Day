/// <summary>
/// 20221224
/// https://leetcode.cn/problems/largest-merge-of-two-strings/
/// </summary>
public class Solution
{
    public string LargestMerge(string word1, string word2)
    {
        var res = "";
        var i = 0;
        var j = 0;
        while (i < word1.Length || j < word2.Length)
        {
            if (i < word1.Length && word1[i..].CompareTo(word2[j..]) > 0)
            {
                res += word1[i++];
            }
            else
            {
                res += word2[j++];
            }
        }

        return res;
    }
}