/// <summary>
/// 20220912
/// https://leetcode.cn/problems/shortest-path-in-binary-matrix/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        if (grid[0][0] == 1) return -1;
        int ans = 0, n = grid.Length;
        // 8 directions
        int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { -1, 1 }, new int[] { 0, 1 }, new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { 1, -1 }, new int[] { 0, -1 }, new int[] { -1, -1 } };
        // Store the current index
        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(new int[] { 0, 0 });
        bool[,] visited = new bool[n, n];
        visited[0, 0] = true;
        while (queue.Count != 0)
        {
            ans++;
            int length = queue.Count;
            // Traverse through this layer
            for (int i = 0; i < length; ++i)
            {
                int[] curr = queue.Dequeue();
                if (curr[0] == n - 1 && curr[1] == n - 1) return ans;
                foreach (int[] direction in directions)
                {
                    int nextX = curr[0] + direction[0], nextY = curr[1] + direction[1];
                    if ((nextX >= 0 && nextX < n) && (nextY >= 0 && nextY < n) && grid[nextX][nextY] == 0 && !visited[nextX, nextY])
                    {
                        visited[nextX, nextY] = true;
                        queue.Enqueue(new int[] { nextX, nextY });
                    }
                }
            }
        }
        return -1;

    }
}