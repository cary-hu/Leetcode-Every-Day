/// <summary>
/// 20220803
/// https://leetcode.cn/problems/orderly-queue/
/// </summary>
public class Solution
{
    public string OrderlyQueue(string s, int k)
    {
        if (k == 1)
        {
            var temp = s + s;
            var min = s;
            for (int i = 0; i < s.Length; i++)
            {
                var currentString = temp.Substring(i, s.Length);
                if (min.CompareTo(currentString) > 0)
                {
                    min = currentString;
                }
            }
            return min;
        }
        else
        {
            return string.Join("", s.OrderBy(x => x).ToList());
        }

    }
}