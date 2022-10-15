/// <summary>
/// 20221015
/// https://leetcode.cn/problems/build-an-array-with-stack-operations/
/// </summary>
public class Solution
{
    public IList<string> BuildArray(int[] target, int n)
    {
        var res = new List<string>();
        int i = 0;
        for (int j = 1; j <= n; j++)
        {
            if (i == target.Length)
            {
                break;
            }
            if (target[i] == j)
            {
                res.Add("Push");
                i++;
            }
            else
            {
                res.Add("Push");
                res.Add("Pop");
            }
        }
        return res;
    }
}