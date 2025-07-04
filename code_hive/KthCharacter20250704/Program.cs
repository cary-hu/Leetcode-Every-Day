/// <summary>
/// 20250704
/// https://leetcode.cn/problems/find-the-k-th-character-in-string-game-ii/
/// </summary>
/// 

new Solution().KthCharacter(10, [0, 1, 0, 1]);
public class Solution
{
    public char KthCharacter(long k, int[] operations)
    {
        char ans = 'a';
        while (k > 1)
        {
            var l = ((int)(Math.Ceiling(Math.Log2(k)) - 1));
            ans = (char)((ans - 'a' + operations[l]) % 26 + 'a');
            k -= (1L << l);
        }
        return ans;
    }
}
