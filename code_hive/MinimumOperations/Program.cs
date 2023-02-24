/// <summary>
/// 20230224
/// https://leetcode.cn/problems/make-array-zero-by-subtracting-equal-amounts/
/// </summary>
public class Solution {
    public int MinimumOperations(int[] nums) {
        return nums.Distinct().Where(x => x > 0).Count();
    }
}