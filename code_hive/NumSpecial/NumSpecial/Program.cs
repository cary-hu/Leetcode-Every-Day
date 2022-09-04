/// <summary>
/// 20220904
/// https://leetcode.cn/problems/special-positions-in-a-binary-matrix/
/// </summary>
public class Solution
{
    public int NumSpecial(int[][] mat)
    {
        var rowNums = new int[mat.Length];
        var columnNums = new int[mat[0].Length];

        for (int i = 0; i < mat.Length; i++)
        {
            for (int j = 0; j < mat[0].Length; j++)
            {
                rowNums[i] += mat[i][j];
                columnNums[j] += mat[i][j];
            }
        }
        var res = 0;
        for (int i = 0; i < mat.Length; i++)
        {
            for (int j = 0; j < mat[0].Length; j++)
            {
                if (mat[i][j] == 1 && rowNums[i] == 1 && columnNums[j] == 1)
                {
                    res++;
                }
            }
        }
        return res;
    }
}