/// <summary>
/// 20220908
/// https://leetcode.cn/problems/beautiful-arrangement-ii/
/// </summary>
public class Solution
{
    public int[] ConstructArray(int n, int k)
    {
        var res = new int[n];

        int numK = k + 1, numTemp = 1;
        for (int i = 0; i <= k; i += 2)
        {
            res[i] = numTemp++;
        }
        for (int i = 1; i <= k; i += 2)
        {
            res[i] = numK--;
        }
        for (int i = k + 1; i < n; ++i)
        {
            res[i] = i + 1;
        }
        return res;
    }
}