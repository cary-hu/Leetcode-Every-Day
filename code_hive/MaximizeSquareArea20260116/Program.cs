/// <summary>
/// 20260116
/// https://leetcode.cn/problems/maximum-square-area-by-removing-fences-from-a-field
/// </summary>
public class Solution
{
    public int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences)
    {
        const int MOD = 1_000_000_007;
        
        List<int> hList = [.. hFences, 1, m];
        List<int> vList = [.. vFences, 1, n];
        
        hList.Sort();
        vList.Sort();
        
        HashSet<int> hDistances = [];
        for (int i = 0; i < hList.Count; i++)
        {
            for (int j = i + 1; j < hList.Count; j++)
            {
                hDistances.Add(hList[j] - hList[i]);
            }
        }
        
        int maxSide = -1;
        for (int i = 0; i < vList.Count; i++)
        {
            for (int j = i + 1; j < vList.Count; j++)
            {
                int distance = vList[j] - vList[i];
                if (hDistances.Contains(distance))
                {
                    maxSide = Math.Max(maxSide, distance);
                }
            }
        }
        
        if (maxSide == -1)
        {
            return -1;
        }
        
        long area = (long)maxSide * maxSide % MOD;
        return (int)area;
    }
}