public class Solution
{
    public long CountMajoritySubarrays(int[] nums, int target)
    {
        int n = nums.Length;
        int[] prefix = new int[n + 1];
        bool hasTarget = false;

        for (int i = 0; i < n; i++)
        {
            int value = nums[i] == target ? 1 : -1;
            hasTarget |= nums[i] == target;
            prefix[i + 1] = prefix[i] + value;
        }

        if (!hasTarget)
        {
            return 0;
        }

        int[] compressed = (int[])prefix.Clone();
        System.Array.Sort(compressed);

        int uniqueCount = 0;
        for (int i = 0; i < compressed.Length; i++)
        {
            if (i == 0 || compressed[i] != compressed[i - 1])
            {
                compressed[uniqueCount++] = compressed[i];
            }
        }

        Fenwick fenwick = new(uniqueCount);
        long answer = 0;

        for (int i = 0; i < prefix.Length; i++)
        {
            int rank = LowerBound(compressed, uniqueCount, prefix[i]) + 1;
            answer += fenwick.Query(rank - 1);
            fenwick.Add(rank, 1);
        }

        return answer;
    }

    private static int LowerBound(int[] values, int length, int target)
    {
        int left = 0;
        int right = length;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (values[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
    }

    private sealed class Fenwick
    {
        private readonly int[] tree;

        public Fenwick(int size)
        {
            tree = new int[size + 1];
        }

        public void Add(int index, int delta)
        {
            while (index < tree.Length)
            {
                tree[index] += delta;
                index += index & -index;
            }
        }

        public int Query(int index)
        {
            int sum = 0;

            while (index > 0)
            {
                sum += tree[index];
                index -= index & -index;
            }

            return sum;
        }
    }
}
