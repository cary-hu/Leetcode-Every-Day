/// <summary>
/// 20221020
/// https://leetcode.cn/problems/k-th-symbol-in-grammar/
/// </summary>
public class Solution
{
    public int KthGrammar(int n, int k)
    {
        int res = 0;
        k--;
        while (k != 0)
        {
            res ^= k & 1;
            k >>= 1;
        }
        return res;
    }

}
