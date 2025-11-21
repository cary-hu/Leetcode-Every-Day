/// <summary>
/// 20251114
/// https://leetcode.cn/problems/increment-submatrices-by-one/
/// </summary>
public class Solution
{
    public int[][] RangeAddQueries(int n, int[][] queries)
    {
        var diff = new int[n + 1, n + 1];
        foreach (var query in queries)
        {
            var r1 = query[0];
            var c1 = query[1];
            var r2 = query[2];
            var c2 = query[3];
            diff[r1, c1]++;
            diff[r1, c2 + 1]--;
            diff[r2 + 1, c1]--;
            diff[r2 + 1, c2 + 1]++;
        }
        var result = new int[n][];
        for (int i = 0; i < n; i++)
        {
            result[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                if (i > 0) diff[i, j] += diff[i - 1, j];
                if (j > 0) diff[i, j] += diff[i, j - 1];
                if (i > 0 && j > 0) diff[i, j] -= diff[i - 1, j - 1];
                result[i][j] = diff[i, j];
            }
        }
        return result;
    }
}