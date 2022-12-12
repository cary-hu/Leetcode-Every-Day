/// <summary>
/// 20221212
/// https://leetcode.cn/problems/sum-of-beauty-of-all-substrings/
/// </summary>
public class Solution
{
    public int BeautySum(string s)
    {
        int n = s.Length;
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            int[] map = new int[26];
            for (int j = i; j < n; j++)
            {
                map[s[j] - 'a']++;
                int max = 0, min = s.Length + 1;
                for (int p = 0; p < map.Length; p++)
                {
                    if (map[p] == 0) continue;
                    max = Math.Max(max, map[p]);
                    min = Math.Min(min, map[p]);
                }
                sum += (max - min);
            }

        }
        return sum;
    }
}