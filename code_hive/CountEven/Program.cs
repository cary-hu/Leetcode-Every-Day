/// <summary>
/// 20220106
/// https://leetcode.cn/problems/count-integers-with-even-digit-sum/
/// </summary>
public class Solution
{
    public int CountEven(int num)
    {
        var res = 0;
        for (int i = 1; i <= num; i++)
        {
            if (isEven(i)) res++;
        }
        return res;
    }
    public bool isEven(int num)
    {
        var sum = 0;
        while (num != 0)
        {
            sum += num % 10;
            num /= 10;
        }
        return sum % 2 == 0;
    }
}