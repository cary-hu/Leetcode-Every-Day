/// <summary>
/// 20220804
/// https://leetcode.cn/problems/minimum-subsequence-in-non-increasing-order/
/// </summary>
public class Solution
{
    public IList<int> MinSubsequence(int[] nums)
    {
        var res = new List<int>();
        var tempNum = nums.ToList().OrderByDescending(x => x).ToList();
        var total = tempNum.Sum();
        for (int i = 0; i < tempNum.Count; i++)
        {
            res.Add(tempNum[i]);
            var resSum = res.Sum();
            
            if (total - resSum < resSum)
            {
                break;
            }
        }
        return res;
    }
}
