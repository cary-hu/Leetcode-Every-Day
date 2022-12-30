/// <summary>
/// 20221230
/// https://leetcode.cn/problems/exam-room/
/// </summary>
public class ExamRoom
{
    List<int> set;
    int Num;
    public ExamRoom(int n)
    {
        set = new List<int>();
        Num = n;
    }

    public int Seat()
    {
        if (set.Count == 0)
        {
            set.Add(0);
            return 0;
        }
        int CurSet = 0;
        int MaxLen = set[0];
        for (int i = 0; i < set.Count - 1; i++)
        {
            int a = set[i];
            int b = set[i + 1];
            if ((b - a) / 2 > MaxLen)
            {
                CurSet = (a + b) / 2;
                MaxLen = (b - a) / 2;
            }
        }
        if (Num - 1 - set[set.Count - 1] > MaxLen)
        {
            CurSet = Num - 1;
        }
        set.Add(CurSet);
        set.Sort();
        return CurSet;
    }

    public void Leave(int p)
    {
        set.Remove(p);
    }
}

/**
 * Your ExamRoom object will be instantiated and called as such:
 * ExamRoom obj = new ExamRoom(n);
 * int param_1 = obj.Seat();
 * obj.Leave(p);
 */