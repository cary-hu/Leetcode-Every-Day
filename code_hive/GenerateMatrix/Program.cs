/// <summary>
/// 20221111
/// https://leetcode.cn/problems/spiral-matrix-ii/
/// </summary>
public class Solution
{
    public int[][] GenerateMatrix(int n)
    {
        var res = new int[n][];
        for (int i = 0; i < n; i++)
        {
            res[i] = new int[n];
        }
        var x = 0;
        var y = 0;
        res[x][y] = 1;
        for (int i = 2; i <= n * n;)
        {
            while (y < n - 1 && res[x][y + 1] == 0) res[x][++y] = i++;
            while (x < n - 1 && res[x + 1][y] == 0) res[++x][y] = i++;
            while (y > 0 && res[x][y - 1] == 0) res[x][--y] = i++;
            while (x > 0 && res[x - 1][y] == 0) res[--x][y] = i++;
        }
        return res;
    }
}