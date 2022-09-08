/// <summary>
/// 20220907
/// https://leetcode.cn/problems/3sum/?envType=study-plan&id=suan-fa-ji-chu
/// </summary>
public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);

        var res = new List<IList<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            if ((i > 0) && (i < nums.Length) && (nums[i] == nums[i - 1]))
            {
                continue;
            }
            int l = i + 1, r = nums.Length - 1;
            while (l < r)
            {
                int s = nums[i] + nums[l] + nums[r];
                if (s > 0) r--;
                else if (s < 0) l++;
                else
                {
                    res.Add(new List<int> { nums[i], nums[l], nums[r] });
                    while (l < r && nums[l] == nums[l + 1]) l++;
                    while (l < r && nums[r] == nums[r - 1]) r--;
                    l++; r--;
                }
            }
        }
        return res;
    }
}