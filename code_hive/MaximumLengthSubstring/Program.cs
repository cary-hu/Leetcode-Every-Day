/// <summary>
/// 20260814
/// https://leetcode.cn/problems/maximum-length-substring-with-two-occurrences/
/// </summary>
public class Solution
{
    public int MaximumLengthSubstring(string s)
    {

        int[] count = new int[26];

        int left = 0;
        int maxLength = 0;

        for (int right = 0; right < s.Length; right++)
        {
            count[s[right] - 'a']++;

            while (count[s[right] - 'a'] > 2)
            {
                count[s[left] - 'a']--;
                left++;
            }

            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}