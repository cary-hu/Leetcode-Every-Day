/// <summary>
/// 20220606
/// https://leetcode.cn/problems/my-calendar-iii/
/// </summary>
public class MyCalendarThree
{
    private SortedDictionary<int, int> _dict = new SortedDictionary<int, int>();
    
    public MyCalendarThree()
    {
        

    }

    public int Book(int start, int end)
    {
        if (_dict.ContainsKey(start))
        {
            _dict[start]++;
        }
        else
        {
            _dict.Add(start, 1);
        }
        if (_dict.ContainsKey(end))
        {
            _dict[end]--;
        }
        else
        {
            _dict.Add(end, -1);
        }
        var ans = 0;
        var maxBook = 0;
        foreach (var item in _dict.Values)
        {
            maxBook += item;
            ans = Math.Max(ans, maxBook);
        }
        return ans;

    }
}

public class MyCalendarThree2
{
    private Dictionary<int, int[]> tree;

    public MyCalendarThree2()
    {
        tree = new Dictionary<int, int[]>();
    }

    public int Book(int start, int end)
    {
        Update(start, end - 1, 0, 1000000000, 1);
        return tree[1][0];
    }

    public void Update(int start, int end, int l, int r, int idx)
    {
        if (r < start || end < l)
        {
            return;
        }
        if (start <= l && r <= end)
        {
            if (!tree.ContainsKey(idx))
            {
                tree.Add(idx, new int[2]);
            }
            tree[idx][0]++;
            tree[idx][1]++;
        }
        else
        {
            int mid = (l + r) >> 1;
            Update(start, end, l, mid, 2 * idx);
            Update(start, end, mid + 1, r, 2 * idx + 1);
            if (!tree.ContainsKey(idx))
            {
                tree.Add(idx, new int[2]);
            }
            if (!tree.ContainsKey(2 * idx))
            {
                tree.Add(2 * idx, new int[2]);
            }
            if (!tree.ContainsKey(2 * idx + 1))
            {
                tree.Add(2 * idx + 1, new int[2]);
            }
            tree[idx][0] = tree[idx][1] + Math.Max(tree[2 * idx][0], tree[2 * idx + 1][0]);
        }
    }
}