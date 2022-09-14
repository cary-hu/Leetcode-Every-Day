/// <summary>
/// 20220914
/// https://leetcode.cn/problems/mean-of-array-after-removing-some-elements/
/// </summary>
public class Solution
{
    public double TrimMean(int[] arr)
    {
        Array.Sort(arr);
        var n = arr.Length;
        var sum = 0;
        for (int i = (int)(n * 0.05); i < (int)(n * 0.95); i++)
        {
            sum += arr[i];
        }
        return sum / (n * 0.9);
    }
}