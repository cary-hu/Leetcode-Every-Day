/// <summary>
/// 20220923
/// https://leetcode.cn/problems/bitwise-and-of-numbers-range/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public int RangeBitwiseAnd(int left, int right)
    {
        var mask = 1 << 30;
        int ans = 0;
        while(mask > 0 && (left & mask) == (right & mask))
        {
            ans |= left & mask;
            mask >>= 1;
        }
        return ans; 
    }
}