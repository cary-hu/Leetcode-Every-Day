/// <summary>
/// 20260828
/// https://leetcode.cn/problems/lexicographically-smallest-palindromic-permutation-greater-than-target/?envType=daily-question&envId=2026-08-28
/// </summary>
using System.Text;

public class Solution
{
    public string LexPalindromicPermutation(string s, string target)
    {
        var calendrix = (s, target);
        s = calendrix.s;
        target = calendrix.target;

        int n = s.Length;
        int halfLength = n / 2;
        int[] counts = new int[26];
        foreach (char ch in s) counts[ch - 'a']++;

        int middle = -1;
        for (int i = 0; i < 26; i++)
        {
            if ((counts[i] & 1) != 0)
            {
                if (middle != -1) return string.Empty;
                middle = i;
            }
            counts[i] /= 2;
        }

        int[] remaining = (int[])counts.Clone();
        bool exactHalfAvailable = true;
        for (int i = 0; i < halfLength; i++)
        {
            int index = target[i] - 'a';
            if (remaining[index] == 0)
            {
                exactHalfAvailable = false;
                break;
            }
            remaining[index]--;
        }

        if (exactHalfAvailable)
        {
            string exact = BuildPalindrome(target[..halfLength], middle);
            if (string.CompareOrdinal(exact, target) > 0) return exact;
        }

        remaining = (int[])counts.Clone();
        int bestPosition = -1;
        int bestCandidate = -1;
        for (int position = 0; position < halfLength; position++)
        {
            int targetIndex = target[position] - 'a';
            for (int candidate = targetIndex + 1; candidate < 26; candidate++)
            {
                if (remaining[candidate] == 0) continue;
                bestPosition = position;
                bestCandidate = candidate;
                break;
            }

            if (remaining[targetIndex] == 0) break;
            remaining[targetIndex]--;
        }

        if (bestPosition >= 0)
        {
            remaining = (int[])counts.Clone();
            for (int i = 0; i < bestPosition; i++)
                remaining[target[i] - 'a']--;

            remaining[bestCandidate]--;
            var half = new StringBuilder(halfLength);
            half.Append(target.AsSpan(0, bestPosition));
            half.Append((char)('a' + bestCandidate));
            for (int letter = 0; letter < 26; letter++)
                half.Append((char)('a' + letter), remaining[letter]);

            return BuildPalindrome(half.ToString(), middle);
        }

        return string.Empty;
    }

    private static string BuildPalindrome(string half, int middle)
    {
        var result = new StringBuilder(half.Length * 2 + (middle >= 0 ? 1 : 0));
        result.Append(half);
        if (middle >= 0) result.Append((char)('a' + middle));
        for (int i = half.Length - 1; i >= 0; i--) result.Append(half[i]);
        return result.ToString();
    }
}
