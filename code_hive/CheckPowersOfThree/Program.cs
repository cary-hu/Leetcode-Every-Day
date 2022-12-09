/// <summary>
/// 20221209
/// https://leetcode.cn/problems/check-if-number-is-a-sum-of-powers-of-three/
/// </summary>
public class Solution
{
    public bool CheckPowersOfThree(int n)
    {
        while (n != 0)
        {
            if (n % 3 > 1)
                return false;
            n /= 3;
        }
        return true;
    }
}