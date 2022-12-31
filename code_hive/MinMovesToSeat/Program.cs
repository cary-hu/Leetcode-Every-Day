/// <summary>
/// 20221231
/// https://leetcode.cn/problems/minimum-number-of-moves-to-seat-everyone/
/// </summary>
public class Solution
{
    public int MinMovesToSeat(int[] seats, int[] students)
    {
        Array.Sort(seats);
        Array.Sort(students);
        int ans = 0;
        for (int i = 0; i < seats.Length; i++)
        {
            ans += Math.Abs(students[i] - seats[i]);
        }
        return ans;
    }
}