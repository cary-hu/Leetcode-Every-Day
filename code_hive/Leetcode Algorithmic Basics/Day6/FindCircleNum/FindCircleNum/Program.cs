using System.Net;
/// <summary>
/// 20220910
/// https://leetcode.cn/problems/number-of-provinces/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public int FindCircleNum(int[][] isConnected)
    {
        int cities = isConnected.Length;
        var visited = new bool[cities];
        int provinces = 0;
        var queue = new Queue<int>();
        for (int i = 0; i < cities; i++)
        {
            if (!visited[i])
            {
                queue.Enqueue(i);
                while(queue.Count > 0)
                {
                    int j = queue.Dequeue();
                    visited[j] = true;
                    for (int k = 0; k < cities; k++)
                    {
                        if (isConnected[j][k] == 1 && !visited[k])
                        {
                            queue.Enqueue(k);
                        }
                    }
                }
                provinces++;
            }
        }

        return provinces;
    }
}