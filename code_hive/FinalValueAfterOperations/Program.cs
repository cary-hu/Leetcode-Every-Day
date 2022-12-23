/// <summary>
/// 20221223
/// https://leetcode.cn/problems/final-value-of-variable-after-performing-operations/
/// </summary>
public class Solution
{
    public int FinalValueAfterOperations(string[] operations)
    {
        var res = 0;
        foreach (var operation in operations)
        {
            if (operation[1] == '+')
            {
                res++;
            } else
            {
                res--;
            }
        }
        return res;
    }
}