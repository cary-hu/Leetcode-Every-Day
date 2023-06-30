/// <summary>
/// 20230630
/// https://leetcode.cn/problems/circular-sentence/
/// </summary>
public class Solution
{
    public bool IsCircularSentence(string sentence)
    {
        for (int i = 0; i < sentence.Length - 1; i++)
        {
            if (sentence[i] == ' ')
            {
                if (sentence[i - 1] != sentence[i + 1])
                {
                    return false;
                }
            }
        }
        if (sentence[^1] == sentence[0])
        {
            return true;
        }
        return false;
    }
}