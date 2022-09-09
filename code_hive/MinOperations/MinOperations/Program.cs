/// <summary>
/// 20220909
/// https://leetcode.cn/problems/crawler-log-folder/
/// </summary>
public class Solution
{
    public int MinOperations(string[] logs)
    {
        var deep = 0;
        foreach (var log in logs)
        {
            if (log == "../")
            {
                if (deep > 0)
                {
                    deep--;
                }
            }
            else if (log == "./")
            {
                continue;
            }
            else
            {
                deep++;
            }
        }
        return deep;
    }
}