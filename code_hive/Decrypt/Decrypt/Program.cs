/// <summary>
/// 20220924
/// https://leetcode.cn/problems/defuse-the-bomb/
/// </summary>
public class Solution
{
    public int[] Decrypt(int[] code, int k)
    {
        var res = new int[code.Length];
        Array.Fill(res, 0);
        if (k > 0)
        {
            for (int i = 0; i < code.Length; i++)
            {
                for (int j = 1; j <= k; j++)
                {
                    res[i] += code[(i + j) % code.Length];
                }
            }
        }
        else if (k < 0)
        {
            for (int i = 0; i < code.Length; i++)
            {
                for (int j = k; j < 0; j++)
                {
                    res[i] += code[(i + j + code.Length) % code.Length];
                }
            }
        }
        return res;
    }
}