using System.Text;
/// <summary>
/// 20221001
/// https://leetcode.cn/problems/reformat-phone-number/
/// </summary>
public class Solution
{
    public string ReformatNumber(string number)
    {
        var digits = number.Replace(" ", "").Replace("-", "");
        int n = digits.Length;
        int pt = 0;
        StringBuilder ans = new StringBuilder();
        while (n > 0)
        {
            if (n > 4)
            {
                ans.Append(digits.Substring(pt, 3) + "-");
                pt += 3;
                n -= 3;
            }
            else
            {
                if (n == 4)
                {
                    ans.Append(digits.Substring(pt, 2) + "-" + digits.Substring(pt + 2, 2));
                }
                else
                {
                    ans.Append(digits.Substring(pt, n));
                }
                break;
            }
        }
        return ans.ToString();
    }
}