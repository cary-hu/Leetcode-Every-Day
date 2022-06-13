/// <summary>
/// 20220613
/// https://leetcode.cn/problems/height-checker/
/// </summary>
public class Solution
{
    public int HeightChecker(int[] heights)
    {
        var res = 0;
        var sorted = heights.ToList().OrderBy(x => x).ToArray();
        
        for (int i = 0; i < heights.Length; i++)
        {
            if (heights[i] != sorted[i])
            {
                res++;
            }
        }
        return res;
    }
}