/// <summary>
/// 20220816
/// https://leetcode.cn/problems/design-an-ordered-stream/
/// </summary>
public class OrderedStream
{
    private SortedDictionary<int, string> dict { get; set; } = new SortedDictionary<int, string>();
    private int _size { get; set; }
    private int ptr { get; set; } = 1;
    public OrderedStream(int n)
    {
        _size = n;
    }

    public IList<string> Insert(int idKey, string value)
    {
        var res = new List<string>();
        dict.Add(idKey, value);
        if (idKey == ptr)
        {
            for (int i = ptr; ; i++)
            {
                if (dict.ContainsKey(i))
                {
                    res.Add(dict[i]);
                } else
                {
                    ptr = i;
                    break;
                }
            }
        }
        return res;
    }
}

/**
 * Your OrderedStream object will be instantiated and called as such:
 * OrderedStream obj = new OrderedStream(n);
 * IList<string> param_1 = obj.Insert(idKey,value);
 */