/// <summary>
/// 20240419
/// https://leetcode.cn/problems/finding-the-users-active-minutes/
/// </summary>
public class Solution
{
    public int[] FindingUsersActiveMinutes(int[][] logs, int k)
    {
        var res = new int[k];
        var allUsers = logs.Select(x => x[0]).Distinct();
        foreach (var user in allUsers)
        {
            var allActionMinuteCount = logs.Where(x => x[0] == user).Select(x => x[1]).Distinct().Count();

            if (allActionMinuteCount == 0)
            {
                continue;
            }
            res[allActionMinuteCount - 1]++;

        }

        return res;
    }
}