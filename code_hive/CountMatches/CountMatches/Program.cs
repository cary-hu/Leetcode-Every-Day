/// <summary>
/// 20221029
/// https://leetcode.cn/problems/count-items-matching-a-rule/
/// </summary>
public class Solution
{
    public int CountMatches(IList<IList<string>> items, string ruleKey, string ruleValue)
    {
        var res = 0;
        var matchIndex = -1;
        switch (ruleKey)
        {
            case "type":
                matchIndex = 0; break;
            case "color":
                matchIndex = 1; break;
            case "name":
                matchIndex = 2; break;
            default:
                break;
        }
        if (matchIndex == -1)
        {
            return res;
        }
        foreach (var item in items)
        {
            if (item[matchIndex] == ruleValue)
            {
                res++;
            }
        }
        return res;
    }
}