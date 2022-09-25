/// <summary>
/// 20220925
/// https://leetcode.cn/problems/rotated-digits/
/// </summary>
public class Solution
{
    public int RotatedDigits(int n)
    {
        int[] check = { 0, 0, 1, -1, -1, 1, 1, -1, 0, 1 };
        int res = 0;
        for (int i = 1; i <= n; ++i)
        {
            string num = i.ToString();
            bool valid = true, diff = false;
            foreach (char ch in num)
            {
                if (check[ch - '0'] == -1)
                {
                    valid = false;
                }
                else if (check[ch - '0'] == 1)
                {
                    diff = true;
                }
            }
            if (valid && diff)
            {
                ++res;
            }
        }
        return res;
    }
}