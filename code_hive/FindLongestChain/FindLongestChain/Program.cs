/// <summary>
/// 20220903
/// https://leetcode.cn/problems/maximum-length-of-pair-chain/
/// </summary>
public class Solution
{
    public int FindLongestChain(int[][] pairs)
    {
        Array.Sort(pairs, (a, b) => { return a[1] - b[1]; });

        var cur = int.MinValue;
        var res = 0;
        foreach (var pair in pairs)
        {
            if(cur < pair[0])
            {
                cur = pair[1];
                res++;
            }
        }

        return res;
    }
}