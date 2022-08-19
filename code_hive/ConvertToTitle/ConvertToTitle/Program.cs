/// <summary>
/// 20220819
/// https://leetcode.cn/problems/excel-sheet-column-title/
/// </summary>
public class Solution
{
    public string ConvertToTitle(int columnNumber)
    {
        var res = new List<char>();
        while (columnNumber != 0)
        {
            columnNumber--;
            res.Add((char)(columnNumber % 26 + 'A'));
            columnNumber /= 26;
        }
        res.Reverse();
        return string.Join("", res);
    }
    public int TitleToNumber(string columnTitle)
    {
        var columnNumber = 0;
        var level = columnTitle.Length - 1;
        for (int i = 0; i < columnTitle.Length; i++)
        {
            var column = columnTitle[i] - 'A' + 1;
            columnNumber += (int)Math.Pow(26, level--) * column;
        }
        return columnNumber;
    }
}