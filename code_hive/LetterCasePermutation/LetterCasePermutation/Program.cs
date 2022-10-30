/// <summary>
/// 20221030
/// https://leetcode.cn/problems/letter-case-permutation/
/// </summary>
public class Solution
{
    private List<string> res = new List<string>();
    public IList<string> LetterCasePermutation(string s)
    {
        Backtrack("", s.ToLower(), 0);
        return res;
    }
    public void Backtrack(string currentString, string targetString, int index)
    {
        if (currentString.Length == targetString.Length)
        {
            res.Add(currentString);
            return;
        }
        var currentChar = targetString[index++];
        if (char.IsDigit(currentChar))
        {
            currentString += currentChar;
            Backtrack(currentString, targetString, index);
        } else
        {
            Backtrack(currentString + currentChar.ToString().ToLower(), targetString, index);
            Backtrack(currentString + currentChar.ToString().ToUpper(), targetString, index);
        }
    }
}