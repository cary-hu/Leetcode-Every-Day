/// <summary>
/// 20220621
/// https://leetcode.cn/problems/defanging-an-ip-address/
/// </summary>
public class Solution
{
    public string DefangIPaddr(string address)
    {
        return address.Replace(".", "[.]");
    }
}