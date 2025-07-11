/// <summary>
/// 20250711
/// https://leetcode.cn/problems/count-days-without-meetings/description/
/// </summary>
public class Solution
{
    public int CountDays(int days, int[][] meetings)
    {
        // Merge meeting
        var mergedMeetings = new List<int[]>();
        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));
        foreach (var meeting in meetings)
        {
            if (mergedMeetings.Count == 0 || mergedMeetings[^1][1] < meeting[0])
            {
                mergedMeetings.Add(meeting);
            }
            else
            {
                mergedMeetings[^1][1] = Math.Max(mergedMeetings[^1][1], meeting[1]);
            }
        }
        // Count days without meetings
        int count = 0;
        int lastEnd = 0;
        foreach (var meeting in mergedMeetings)
        {
            int start = meeting[0];
            int end = meeting[1];
            count += Math.Max(0, start - lastEnd - 1);
            lastEnd = end;
        }
        count += Math.Max(0, days - lastEnd);
        return count;
    }
}