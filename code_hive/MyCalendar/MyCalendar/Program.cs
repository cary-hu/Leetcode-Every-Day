/// <summary>
/// 20220507
/// https://leetcode.cn/problems/my-calendar-i/
/// https://leetcode.cn/problems/my-calendar-ii/
/// https://leetcode.cn/problems/my-calendar-iii/
/// </summary>
public class MyCalendar
{
    IList<Tuple<int, int>> booked;

    public MyCalendar()
    {
        booked = new List<Tuple<int, int>>();
    }

    public bool Book(int start, int end)
    {
        foreach (Tuple<int, int> tuple in booked)
        {
            int l = tuple.Item1, r = tuple.Item2;
            if (l < end && start < r)
            {
                return false;
            }
        }
        booked.Add(new Tuple<int, int>(start, end));
        return true;
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */

public class MyCalendarTwo
{
    private List<int[]> calendar = new List<int[]>();
    private List<int[]> overlaps = new List<int[]>();
    
    public MyCalendarTwo()
    {

    }

    public bool Book(int start, int end)
    {
        foreach (var item in overlaps)
        {
            if (item[0] < end && start < item[1]) return false;
        }
        foreach (var item in calendar)
        {
            if (item[0] < end && start < item[1])
                overlaps.Add(new int[] { Math.Max(start, item[0]), Math.Min(end, item[1]) });

        }
        calendar.Add(new int[] { start, end });
        return true;
    }
}

/**
 * Your MyCalendarTwo object will be instantiated and called as such:
 * MyCalendarTwo obj = new MyCalendarTwo();
 * bool param_1 = obj.Book(start,end);
 */

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

/**
 * Your MyCalendarThree object will be instantiated and called as such:
 * MyCalendarThree obj = new MyCalendarThree();
 * int param_1 = obj.Book(start,end);
 */