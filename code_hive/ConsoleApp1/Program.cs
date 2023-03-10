/// <summary>
/// 20230310
/// https://leetcode.cn/problems/make-sum-divisible-by-p/
/// </summary>
public class Solution {
    public int MinSubarray(int[] nums, int p) {
        int x = 0;
        foreach (int num in nums) {
            x = (x + num) % p;
        }
        if (x == 0) {
            return 0;
        }
        IDictionary<int, int> index = new Dictionary<int, int>();
        int y = 0, res = nums.Length;
        for (int i = 0; i < nums.Length; i++) {
            // f[i] mod p = y，因此哈希表记录 y 对应的下标为 i
            if (!index.ContainsKey(y)) {
                index.Add(y, i);
            }
            else {
                index[y] = i;
            }
            y = (y + nums[i]) % p;
            if (index.ContainsKey((y - x + p) % p)) {
                res = Math.Min(res, i - index[(y - x + p) % p] + 1);
            }
        }
        return res == nums.Length ? -1 : res;
    }
}