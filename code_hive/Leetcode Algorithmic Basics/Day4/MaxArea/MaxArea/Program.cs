public class Solution
{
    public int MaxArea(int[] height)
    {
        var res = int.MinValue;
        var i = 0;
        var j = height.Length - 1;
        while (i < j)
        {
            res = Math.Max(res, Math.Min(height[i], height[j]) * (j - i));
            _ = height[i] > height[j] ? j-- : i++;
        }
        return res;
    }
}