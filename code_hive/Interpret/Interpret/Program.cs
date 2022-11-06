/// <summary>
/// 20221106
/// https://leetcode.cn/problems/goal-parser-interpretation/
/// </summary>
public class Solution
{
    public string Interpret(string command)
    {
        return command.Replace("()", "o").Replace("(al)", "al");
    }
}