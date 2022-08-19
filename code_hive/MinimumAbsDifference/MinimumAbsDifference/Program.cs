/// <summary>
/// 20220407
/// https://leetcode.cn/problems/minimum-absolute-difference/
/// </summary>
public class Solution
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        Array.Sort(arr);
        int min = int.MaxValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (i + 1 >= arr.Length)
            {
                break;
            }
            min = Math.Min(min, Math.Abs(arr[i] - arr[i + 1]));
        }
        var res = new List<IList<int>>();
        for (int i = 0; i < arr.Length;)
        {
            if (i + 1 >= arr.Length)
            {
                break;
            }
            if (Math.Abs(arr[i] - arr[i + 1]) == min)
            {
                res.Add(new List<int>()
                {
                    arr[i++],
                    arr[i]
                });
            }
            else
            {
                i++;
            }
        }
        return res;
    }
}