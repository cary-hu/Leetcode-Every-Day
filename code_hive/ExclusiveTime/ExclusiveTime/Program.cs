/// <summary>
/// 20220807
/// https://leetcode.cn/problems/exclusive-time-of-functions/
/// </summary>
public class Solution
{
    public int[] ExclusiveTime(int n, IList<string> logs)
    {
        var stack = new Stack<(int functionId, int timeStamp, string action, int tempEnd)>();
        int[] res = new int[n];
        foreach (var log in logs)
        {
            var logParts = log.Split(":");
            var functionId = int.Parse(logParts[0]);
            var action = logParts[1];
            var timeStamp = int.Parse(logParts[2]);
            if (action == "start")
            {
                stack.Push((functionId, timeStamp, action, 0));
            }
            if (action == "end")
            {
                var stackHead = stack.Pop();
                int interval = timeStamp - stackHead.timeStamp + 1;
                res[functionId] += interval;
                if(stack.Count > 0)
                {
                    res[stack.Peek().functionId] -= interval;
                }
            }
        }
        return res;
    }
}