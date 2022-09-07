using System.Text;

var a = new Solution();
a.ReorderSpaces("  hello");
/// <summary>
/// 20220907
/// https://leetcode.cn/problems/rearrange-spaces-between-words/
/// </summary>
public class Solution
{
    public string ReorderSpaces(string text)
    {
        var words = text.Split(" ").Where(x => x != "");
        var spaceCount = 0;
        foreach (char item in text)
        {
            if (item == ' ')
            {
                spaceCount++;
            }
        }
        if(spaceCount == 0)
        {
            return text;
        }
        if(words.Count() == 1)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(words.First());
            for (int i = 0; i < spaceCount; i++)
            {
                sb.Append(' ');
            }
            return sb.ToString();
        }
        var spaceItem = spaceCount / (words.Count() - 1);
        var spaceLast = spaceCount % (words.Count() - 1);
        var res = "";
        var index = 0;
        foreach (var word in words)
        {
            res += word;
            if(index == words.Count() - 1)
            {
                break;
            }
            for (int i = 0; i < spaceItem; i++)
            {
                res += " ";
            }
            index++;
        }
        for (int i = 0; i < spaceLast; i++)
        {
            res += " ";
        }
        return res;
    }
}