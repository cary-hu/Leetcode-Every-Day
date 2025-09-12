/// <summary>
/// 20250912
/// https://leetcode.cn/problems/vowels-game-in-a-string/description
/// </summary>
public class Solution
{
    public bool DoesAliceWin(string s)
    {
        foreach (var c in s)
        {
            if ("aeiou".Contains(c))
            {
                return true;
            }
        }
        return false;
    }
}