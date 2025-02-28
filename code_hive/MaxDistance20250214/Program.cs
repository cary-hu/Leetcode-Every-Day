/// <summary>
/// 20250214
/// https://leetcode.cn/problems/magnetic-force-between-two-balls/
/// </summary>
public class Solution
{
    public int MaxDistance(int[] position, int m)
    {
        Array.Sort(position);
        if (m == 2)
        {
            return position[^1] - position[0];
        }
        int left = 1;
        int right = position[^1] - position[0];
        while (left < right)
        {
            int mid = (left + right) / 2;
            if (Check(position, mid, m))
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }
        return left - 1;
    }
    private static bool Check(int[] position, int mid, int m)
    {
        int count = 1;
        int pre = position[0];
        for (int i = 1; i < position.Length; i++)
        {
            if (position[i] - pre >= mid)
            {
                count++;
                pre = position[i];
            }
        }
        return count >= m;
    }
}