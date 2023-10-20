/// <summary>
/// 20231013
/// https://leetcode.cn/problems/avoid-flood-in-the-city/
/// </summary>
new Solution().AvoidFlood(new int[] { 1, 2, 3, 4 });
public class LakeInfo
{
    public int LakeId { get; set; }
    public bool IsFull { get; set; }
}
public class Solution
{
    public int[] AvoidFlood(int[] rains)
    {
        var res = new int[rains.Length];
        Array.Fill(res, -1);

        var notRainDays = new int[rains.Length];
        Array.Fill(res, 0);

        var lake = new List<LakeInfo>();

        for (int i = 0; i < rains.Length; i++)
        {
            if (rains[i] == 0)
            {
                notRainDays[i] = 1;
            }
        }

        for (int i = 0; i < rains.Length; i++)
        {
            var lakeInfo = lake.Find(x => x.LakeId == rains[i]);
            if (lakeInfo == null)
            {
                lakeInfo = new LakeInfo()
                {
                    LakeId = rains[i],
                    IsFull = false
                };
                lake.Add(lakeInfo);
            }
            if (rains[i] >= 1)
            {
                if (lakeInfo.IsFull)
                {
                    for (int j = i + 1; j < notRainDays.Length; j++)
                    {
                        if (notRainDays[j] == 1)
                        {
                            lakeInfo.IsFull = false; notRainDays[j] = 0;
                            res[j] = lakeInfo.LakeId;
                            break;
                        }
                    }
                    if (lakeInfo.IsFull)
                    {
                        return new int[0];
                    }
                    lakeInfo.IsFull = true;
                }
                else
                {
                    lakeInfo.IsFull = true;
                }
            }
        }
        return res;
    }
}