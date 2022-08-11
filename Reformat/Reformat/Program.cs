/// <summary>
/// 20220811
/// https://leetcode.cn/problems/reformat-the-string/
/// </summary>
public class Solution
{
    public string Reformat(string s)
    {
        var letters = new List<char>();
        var digits = new List<char>();
        foreach (var item in s)
        {
            if (char.IsDigit(item))
            {
                digits.Add(item);
            }
            else
            {
                letters.Add(item);
            }
        }
        if (Math.Abs(letters.Count - digits.Count) > 1)
        {
            return "";
        }
        var res = "";
        if (letters.Count > digits.Count)
        {
            for (int i = 0; i < letters.Count;i++)
            {
                res += letters[i];
                if(i < digits.Count)
                {

                res += digits[i];
                }
            }
        } else
        {
            for (int i = 0; i < digits.Count; i++)
            {
                res += digits[i];
                if (i < letters.Count)
                {

                    res += letters[i];
                }
            }
        }
        return res;
    }
}