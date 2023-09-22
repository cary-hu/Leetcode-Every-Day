/// <summary>
/// 20230922
/// https://leetcode.cn/problems/distribute-money-to-maximum-children
/// </summary>
public class Solution
{
    public int DistMoney(int money, int children)
    {
        if (money < children)
        {
            return -1;
        }
        int tmp = children * 8 - money;
        if (tmp == 4) return children - 2;
        if (tmp < 0) return children - 1;
        return (money - children) / 7;
    }
}