/// <summary>
/// 20221203
/// https://leetcode.cn/problems/second-largest-digit-in-a-string/
/// </summary>
public class Solution
{
    public int SecondHighest(string s)
    {
        var dict = new List<int>();
        var pq = new PriorityQueue<int, int>();
        foreach (var charItem in s)
        {
            if (char.IsDigit(charItem))
            {
                var tempNumber = charItem - '0';
                if (!dict.Contains(tempNumber))
                {
                    dict.Add(tempNumber);
                }
            }
        }
        if (dict.Count < 2)
        {
            return -1;
        }
        return dict.OrderByDescending(x => x).ToList()[1];
    }
}