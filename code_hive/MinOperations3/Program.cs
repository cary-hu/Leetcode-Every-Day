/// <summary>
/// 20221202
/// https://leetcode.cn/problems/minimum-number-of-operations-to-move-all-balls-to-each-box/
/// </summary>
public class Solution
{
    public int[] MinOperations(string boxes)
    {
        var res = new int[boxes.Length];
        for (int i = 0; i < boxes.Length; i++)
        {
            var currentRes = 0;
            for (int j = 0; j < i; j++)
            {
                if (boxes[j] == '1')
                {
                    currentRes += Math.Abs(i - j);
                }
            }
            for (int j = i + 1; j < boxes.Length; j++)
            {
                if (boxes[j] == '1')
                {
                    currentRes += Math.Abs(i - j);
                }
            }

            res[i] = currentRes;
        }
        return res;
    }
}