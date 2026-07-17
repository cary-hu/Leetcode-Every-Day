/// <summary>
/// 20260717
/// https://leetcode.cn/problems/sorted-gcd-pair-queries/
/// </summary>
public class Solution
{
    public int[] GcdValues(int[] nums, long[] queries)
    {
        int maxValue = 0;
        foreach (int num in nums)
        {
            if (num > maxValue)
            {
                maxValue = num;
            }
        }

        int[] frequency = new int[maxValue + 1];
        foreach (int num in nums)
        {
            frequency[num]++;
        }

        long[] gcdPairCount = new long[maxValue + 1];
        for (int gcd = maxValue; gcd >= 1; gcd--)
        {
            long multipleCount = 0;
            for (int multiple = gcd; multiple <= maxValue; multiple += gcd)
            {
                multipleCount += frequency[multiple];
            }

            long pairCount = multipleCount * (multipleCount - 1) / 2;
            for (int multiple = gcd + gcd; multiple <= maxValue; multiple += gcd)
            {
                pairCount -= gcdPairCount[multiple];
            }

            gcdPairCount[gcd] = pairCount;
        }

        long[] prefix = new long[maxValue + 1];
        for (int gcd = 1; gcd <= maxValue; gcd++)
        {
            prefix[gcd] = prefix[gcd - 1] + gcdPairCount[gcd];
        }

        int[] result = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            long target = queries[i] + 1;
            int left = 1;
            int right = maxValue;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (prefix[mid] >= target)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            result[i] = left;
        }

        return result;
    }
}