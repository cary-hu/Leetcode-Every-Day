/// <summary>
/// 20220902
/// https://leetcode.cn/problems/maximum-number-of-words-you-can-type/
/// </summary>
public class Solution
{
    public int CanBeTypedWords(string text, string brokenLetters)
    {
        var words = text.Split(" ");
        var res = words.Length;
        foreach (var word in words)
        {
            for (int j = 0; j < word.Length; j++)
            {
                var charector = word[j];
                if (brokenLetters.Contains(charector))
                {
                    res--;
                    break;
                }
            }
        }
        return res;
    }
}