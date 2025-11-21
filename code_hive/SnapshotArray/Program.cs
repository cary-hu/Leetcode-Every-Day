/// <summary>
/// 20240426
/// https://leetcode.cn/problems/snapshot-array/
/// </summary>
public class SnapshotArray
{
    private int SnapId = 0;
    public List<Tuple<int, int>>[] lists;
    public SnapshotArray(int length)
    {
        lists = new List<Tuple<int, int>>[length];
        for (int i = 0; i < length; i++)
        {
            lists[i] = [new Tuple<int, int>(0, 0)];
        }
    }

    public void Set(int index, int val)
    {
        lists[index].Add(new Tuple<int, int>(SnapId, val));
    }

    public int Snap()
    {
        return SnapId++;
    }

    public int Get(int index, int snap_id)
    {
        var item = lists[index];

        if (item.Count <= snap_id)
        {
            return item.Last().Item2;
        }
        else
        {
            var lastSnap = item.LastOrDefault(x => x.Item1 <= snap_id);
            if (lastSnap == null)
            {
                return 0;
            }
            return lastSnap.Item2;
        }
    }
}

/**
 * Your SnapshotArray object will be instantiated and called as such:
 * SnapshotArray obj = new SnapshotArray(length);
 * obj.Set(index,val);
 * int param_2 = obj.Snap();
 * int param_3 = obj.Get(index,snap_id);
 */
