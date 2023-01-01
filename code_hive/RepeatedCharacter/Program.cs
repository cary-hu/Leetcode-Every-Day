/// <summary>
/// 20230101
/// https://leetcode.cn/problems/first-letter-to-appear-twice/
/// </summary>
public class Solution
{
    public char RepeatedCharacter(string s)
    {
        var dict = new Dictionary<char, int>();
        foreach (var charItem in s)
        {
            if (dict.ContainsKey(charItem))
            {
                return charItem;
            }
            dict.Add(charItem, 1);
        }
        return '';
    }
}