/// <summary>
/// 20220819
/// https://leetcode.cn/problems/number-of-students-doing-homework-at-a-given-time/
/// </summary>
public class Solution
{
    public int BusyStudent(int[] startTime, int[] endTime, int queryTime)
    {
        var res = 0;
        var studentCount = startTime.Length;
        for (int i = 0; i < studentCount; i++)
        {
            if(queryTime >= startTime[i] && queryTime <= endTime[i])
            {
                res++;
            }
        }
        return res;
    }
}