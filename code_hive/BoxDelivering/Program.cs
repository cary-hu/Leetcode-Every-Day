/// <summary>
/// 20221205
/// https://leetcode.cn/problems/delivering-boxes-from-storage-to-ports
/// </summary>
public class Solution
{
    public int BoxDelivering(int[][] boxes, int portsCount, int maxBoxes, int maxWeight)
    {
        int n = boxes.Length;
        if (n <= maxBoxes) // 处理能够一次装完的特殊情况
        {
            var sumWeight = 0;
            int prevPorts = -1;
            int res = 1;
            bool flag = true;
            foreach (var item in boxes)
            {
                sumWeight += item[1];
                if (sumWeight > maxWeight)
                {
                    flag = false;
                    break;
                }
                if (item[0] != prevPorts)
                {
                    res++;
                    prevPorts = item[0];
                }
            }
            if (flag)
            {
                return res;
            }
        }
        var dp = new int[n + 1];
        for (int i = n - 1; i >= 0; i--)
        {
            int min = 2 + dp[i + 1];
            int weight = boxes[i][1];
            int boxCount = 1;
            List<int> targetPorts = new List<int>() { boxes[i][0] };
            for (int j = i + 1; j < n; j++)
            {
                weight += boxes[j][1];
                boxCount++;
                if (weight > maxWeight) break;
                if (boxCount > maxBoxes) break;
                if (boxes[j][0] != targetPorts[targetPorts.Count - 1])
                {
                    targetPorts.Add(boxes[j][0]);
                }
                min = Math.Min(min, targetPorts.Count + 1 + dp[j + 1]);
            }
            dp[i] = min;
        }
        return dp[0];
    }
}