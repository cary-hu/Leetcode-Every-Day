/// <summary>
/// 20221101
/// https://leetcode.cn/problems/check-if-two-string-arrays-are-equivalent/
/// </summary>
public class Solution
{
    public bool ArrayStringsAreEqual(string[] word1, string[] word2)
    {
        return string.Join("", word1) == string.Join("", word2);
    }
}