/// <summary>
/// 20221206
/// https://leetcode.cn/problems/number-of-different-integers-in-a-string/
/// </summary>
public class Solution
{
    public int NumDifferentIntegers(string word)
    {
        ISet<string> set = new HashSet<string>();
        int n = word.Length, p1 = 0, p2;
        while (true)
        {
            while (p1 < n && !char.IsDigit(word[p1]))
            {
                p1++;
            }
            if (p1 == n)
            {
                break;
            }
            p2 = p1;
            while (p2 < n && char.IsDigit(word[p2]))
            {
                p2++;
            }
            while (p2 - p1 > 1 && word[p1] == '0')
            {
                p1++;
            }
            set.Add(word[p1..p2]);
            p1 = p2;
        }
        return set.Count;
    }
}