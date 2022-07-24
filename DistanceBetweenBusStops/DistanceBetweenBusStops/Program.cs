/// <summary>
/// 20220724
/// https://leetcode.cn/problems/distance-between-bus-stops/
/// </summary>
public class Solution
{
    public int DistanceBetweenBusStops(int[] distance, int start, int destination)
    {
        if (start > destination)
        {
            int temp = start;
            start = destination;
            destination = temp;
        }
        int sum1 = 0, sum2 = 0;
        for (int i = 0; i < distance.Length; i++)
        {
            if (i >= start && i < destination)
            {
                sum1 += distance[i];
            }
            else
            {
                sum2 += distance[i];
            }
        }
        return Math.Min(sum1, sum2);
    }
}