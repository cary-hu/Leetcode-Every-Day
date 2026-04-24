/// <summary>
/// 20260417
/// https://leetcode.cn/problems/minimum-absolute-distance-between-mirror-pairs/
/// </summary>
public class Solution
{
    public int MinMirrorPairDistance(int[] nums)
    {
        if (nums.Length < 2)
        {
            return -1;
        }

        int res = int.MaxValue;
        var map = new IntIntMap(nums.Length);
        for (int i = 0; i < nums.Length; i++)
        {
            if (map.TryGetValue(nums[i], out int index))
            {
                int distance = i - index;
                if (distance < res)
                {
                    if (distance == 1)
                    {
                        return 1;
                    }

                    res = distance;
                }
            }

            int reversed = Reverse(nums[i]);
            map.Set(reversed, i);
        }

        return res == int.MaxValue ? -1 : res;

    }

    private static int Reverse(int num)
    {
        if (num < 10)
        {
            return num;
        }

        int res = 0;
        while (num != 0)
        {
            res = res * 10 + num % 10;
            num /= 10;
        }

        return res;
    }

    private sealed class IntIntMap
    {
        private int[] _keys;
        private int[] _values;
        private byte[] _used;
        private int _count;

        public IntIntMap(int capacity)
        {
            int size = 4;
            int target = capacity <= 3 ? 4 : (capacity * 4 + 2) / 3;
            while (size < target)
            {
                size <<= 1;
            }

            _keys = new int[size];
            _values = new int[size];
            _used = new byte[size];
        }

        public bool TryGetValue(int key, out int value)
        {
            int mask = _keys.Length - 1;
            int index = Hash(key) & mask;
            while (_used[index] != 0)
            {
                if (_keys[index] == key)
                {
                    value = _values[index];
                    return true;
                }

                index = (index + 1) & mask;
            }

            value = default;
            return false;
        }

        public void Set(int key, int value)
        {
            if ((_count + 1) * 4 > _keys.Length * 3)
            {
                Resize();
            }

            int mask = _keys.Length - 1;
            int index = Hash(key) & mask;
            while (_used[index] != 0)
            {
                if (_keys[index] == key)
                {
                    _values[index] = value;
                    return;
                }

                index = (index + 1) & mask;
            }

            _used[index] = 1;
            _keys[index] = key;
            _values[index] = value;
            _count++;
        }

        private void Resize()
        {
            int[] oldKeys = _keys;
            int[] oldValues = _values;
            byte[] oldUsed = _used;

            int newSize = oldKeys.Length << 1;
            _keys = new int[newSize];
            _values = new int[newSize];
            _used = new byte[newSize];

            int mask = newSize - 1;
            for (int i = 0; i < oldKeys.Length; i++)
            {
                if (oldUsed[i] == 0)
                {
                    continue;
                }

                int key = oldKeys[i];
                int index = Hash(key) & mask;
                while (_used[index] != 0)
                {
                    index = (index + 1) & mask;
                }

                _used[index] = 1;
                _keys[index] = key;
                _values[index] = oldValues[i];
            }
        }

        private static int Hash(int key)
        {
            int hash = key * -1640531527;
            return hash ^ (hash >>> 16);
        }
    }
}