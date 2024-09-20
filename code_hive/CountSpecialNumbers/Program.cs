/// <summary>
/// 20240920
/// https://leetcode.cn/problems/count-special-integers/
/// </summary>
/// 
new Solution().CountSpecialNumbers(20);
public class Solution
{
    public int Res = 0;
    public int CountSpecialNumbers(int n)
    {
        for (int i = 1; i <= 9; i++)
        {
            CheckNumber(i, 1 << i, n);
        }
        return Res;
    }

    public void CheckNumber(long s, int used, int n)
    {
        if (s > n)
        {
            return;
        }
        Res++;
        for (int i = 0; i <= 9; i++)
        {
            if ((used & (1 << i)) == 0)
            {
                CheckNumber(s * 10 + i, used | (1 << i), n);
            }
        }
    }
}