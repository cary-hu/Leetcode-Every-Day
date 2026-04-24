/// <summary>
/// 20260424
/// https://leetcode.cn/problems/furthest-point-from-origin
/// </summary>
public class Solution
{
    public int FurthestDistanceFromOrigin(string moves)
    {
        uint state = 0;

        foreach (var move in moves)
        {
            if (move == 'L')
            {
                state = (state & 0xFFFF0000u) | (ushort)((short)state - 1);
            }
            else if (move == 'R')
            {
                state = (state & 0xFFFF0000u) | (ushort)((short)state + 1);
            }
            else
            {
                state += 1u << 16;
            }
        }

        return Math.Abs((short)state) + (int)(state >> 16);
    }
}