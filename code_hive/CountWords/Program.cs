/// <summary>
/// 20240112
/// https://leetcode.cn/problems/count-common-words-with-one-occurrence/
/// </summary>
public class Solution
{
    public int CountWords(string[] words1, string[] words2)
    {
        var freq1 = new Dictionary<string, int>();
        var freq2 = new Dictionary<string, int>();
        foreach (string w in words1)
        {
            freq1[w] = freq1.GetValueOrDefault(w, 0) + 1;
        }
        foreach (string w in words2)
        {
            freq2[w] = freq2.GetValueOrDefault(w, 0) + 1;
        }

        // 遍历 words1 出现的字符串并检查个数
        int res = 0;
        foreach (var w in freq1)
        {
            if (w.Value == 1 && freq2.GetValueOrDefault(w.Key, 0) == 1)
            {
                res++;
            }
        }
        return res;
    }
}