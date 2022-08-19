using System.Text;
/// <summary>
/// 20220707
/// https://leetcode.cn/problems/replace-words/
/// </summary>
public class Solution
{
    public string ReplaceWords(IList<string> dictionary, string sentence)
    {
        var words = sentence.Split(' ');
        var result = new StringBuilder();
        dictionary = dictionary.OrderBy(x => x.Length).ToList();
        var res = "";
        foreach (var item in words)
        {
            var root = dictionary.Where(x => item.StartsWith(x)).FirstOrDefault();
            if(!string.IsNullOrEmpty(root))
            {
                res = root;
            }
            else
            {
                res = item;
            }
            result.Append(res + " ");
        }
        return result.ToString().Trim();
    }
}