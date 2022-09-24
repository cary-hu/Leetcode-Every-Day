/// <summary>
/// 20220924
/// https://leetcode.cn/problems/happy-number/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public bool IsHappy(int n)
    {
        var dict = new Dictionary<int, int>();
        int m = n;
        while (true)
        {
            int sum = 0;
            while (m != 0)
            {
                sum += (m % 10) * (m % 10);
                m /= 10;
            }
            if (sum == 1)
            {
                return true;
            }
            else if (dict.ContainsKey(sum))
            {
                return false;
            }
            else
            {
                dict.Add(sum, 0);
            }

            m = sum;
        }
    }
}