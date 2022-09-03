/// <summary>
/// 20220829
/// https://leetcode.cn/problems/shuffle-the-array/
/// </summary>
public class Solution
{
    public int[] Shuffle(int[] nums, int n)
    {
        var a = 0;
        var b = n + 1;
        var res = new int[2 * n];
        var flip = true;
        for (int i = 0; i < nums.Length; i++)
        {
            if(flip)
            {
                res[i] = nums[a++];

            } else
            {

                res[i] = nums[b++];
            }
            flip = !flip;
        }
        return res;
    }
}