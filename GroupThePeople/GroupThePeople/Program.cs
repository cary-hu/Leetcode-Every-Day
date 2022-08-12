using System.Linq;
/// <summary>
/// 20220812
/// https://leetcode.cn/problems/group-the-people-given-the-group-size-they-belong-to/
/// </summary>
public class Solution
{
    public IList<IList<int>> GroupThePeople(int[] groupSizes)
    {
        var groupMap = new Dictionary<int, List<int>>();
        for (int i = 0; i < groupSizes.Length; i++)
        {
            if (groupMap.ContainsKey(groupSizes[i]))
            {
                groupMap[groupSizes[i]].Add(i);
            } else
            {
                groupMap.Add(groupSizes[i], new List<int>() { i });
            }
        }
        var res = new List<IList<int>>();
        foreach (var mapItem in groupMap)
        {
            var groupSize = mapItem.Key;
            var groupItems = mapItem.Value;
            for (int i = 0; i < groupItems.Count;)
            {
                var tempList = new List<int>();
                for (int j = 0; j < groupSize; j++)
                {
                    tempList.Add(groupItems[i++]);
                }
                res.Add(tempList);
            }
        }
        return res;
    }
}