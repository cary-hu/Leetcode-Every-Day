/// <summary>
/// 20240322
/// https://leetcode.cn/problems/adding-spaces-to-a-string/
/// </summary>
public class Solution
{
    public string AddSpaces(string s, int[] spaces)
    {
        var chars = new char[s.Length + spaces.Length];
        for (int i = 0, j = 0; i < s.Length; i++)
        {
            if (j >= spaces.Length)
            {
                chars[i + j] = s[i];
                continue;
            }
            var currentSpace = spaces[j];
            if (currentSpace == i)
            {
                chars[i + j] = ' ';
                j++;
            }
            chars[i + j] = s[i];
        }
        return new string(chars);
    }
}