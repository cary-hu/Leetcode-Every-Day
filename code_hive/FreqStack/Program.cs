/// <summary>
/// 20221130
/// https://leetcode.cn/problems/maximum-frequency-stack/
/// </summary>
public class FreqStack
{
    private int Size { get; set; }
    private List<Tuple<int, int, List<int>>> InnerList { get; set; } = new List<Tuple<int, int, List<int>>>();
    public void Push(int val)
    {
        Size++;
        var item = InnerList.Find(x => x.Item1 == val);
        if (item == null)
        {
            InnerList.Add(new Tuple<int, int, List<int>>(val, 1, new List<int>() { Size }));
        }
        else
        {
            InnerList.Remove(item);
            var currentIndexes = item.Item3;
            currentIndexes.Add(Size);
            InnerList.Add(new Tuple<int, int, List<int>>(val, item.Item2 + 1, currentIndexes));
        }
    }

    public int Pop()
    {
        InnerList.Sort((a, b) =>
        {
            if (a.Item2 == b.Item2)
            {
                return b.Item3.Max() - a.Item3.Max();
            }
            else
            {
                return b.Item2 - a.Item2;
            }
        });
        var item = InnerList[0];
        InnerList.Remove(item);

        var currentIndexes = item.Item3;
        currentIndexes.Remove(currentIndexes.Last());
        if (currentIndexes.Any())
        {
            InnerList.Add(new Tuple<int, int, List<int>>(item.Item1, item.Item2 - 1, currentIndexes));
        }
        return item.Item1;
    }
}
public class FreqStack2
{
    private IDictionary<int, int> freq;
    private IDictionary<int, Stack<int>> group;
    private int maxFreq;

    public FreqStack2()
    {
        freq = new Dictionary<int, int>();
        group = new Dictionary<int, Stack<int>>();
        maxFreq = 0;
    }

    public void Push(int val)
    {
        if (!freq.ContainsKey(val))
        {
            freq.Add(val, 0);
        }
        freq[val]++;
        if (!group.ContainsKey(freq[val]))
        {
            group.Add(freq[val], new Stack<int>());
        }
        group[freq[val]].Push(val);
        maxFreq = Math.Max(maxFreq, freq[val]);
    }

    public int Pop()
    {
        int val = group[maxFreq].Peek();
        freq[val]--;
        group[maxFreq].Pop();
        if (group[maxFreq].Count == 0)
        {
            maxFreq--;
        }
        return val;
    }
}