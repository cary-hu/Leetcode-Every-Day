/// <summary>
/// 20231201
/// https://leetcode.cn/problems/first-completely-painted-row-or-column/
/// </summary>
public class Solution
{
    public int FirstCompleteIndex(int[] arr, int[][] mat)
    {
        var matCount = mat[0].Length;
        var matLength = mat.Length;
        var rowPaintList = new int[matLength];
        var colPaintList = new int[matCount];

        Array.Fill(rowPaintList, 0);
        Array.Fill(colPaintList, 0);
        
        var positionMapping = new Dictionary<int, Tuple<int, int>>();
        for (int i = 0; i < matLength; ++i)
        {
            for (int j = 0; j < matCount; ++j)
            {
                positionMapping.Add(mat[i][j], new Tuple<int, int>(i, j));
            }
        }

        for (int i = 0; i < arr.Length; i++)
        {
            Tuple<int, int> v = positionMapping[arr[i]];
            rowPaintList[v.Item1]++;
            colPaintList[v.Item2]++;
            if (rowPaintList[v.Item1] == matCount || colPaintList[v.Item2] == matLength)
            {
                return i;
            }
        }
        return -1;
    }
}