var a = new Solution();
a.FindSubstring("wordgoodgoodgoodbestword", new string[] { "word", "good", "best", "good" });
/// <summary>
/// 20220623
/// https://leetcode.cn/problems/substring-with-concatenation-of-all-words/
/// </summary>
public class Solution
{
    public IList<int> FindSubstring(string s, string[] words)
    {
        var res = new List<int>();
        var wordLength = words[0].Length;
        var strLength = wordLength * words.Length;
        for (int i = 0; i < s.Length - strLength + 1; i++)
        {
            var isMatch = true;
            var dict = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (dict.ContainsKey(word))
                {
                    dict[word]++;
                }
                else
                {
                    dict.Add(word, 1);
                }
            }
            for (int j = i; j < i + strLength;)
            {
                var tempStr = s.Substring(j, wordLength);
                if (!dict.ContainsKey(tempStr))
                {
                    isMatch = false;
                    break;
                }
                if (dict[tempStr] > 0)
                {
                    dict[tempStr]--;
                }
                j += wordLength;

            }
            if (isMatch)
            {
                if (!dict.Any(x => x.Value > 0))
                {
                    res.Add(i);
                }
            }
        }

        return res;
    }
}