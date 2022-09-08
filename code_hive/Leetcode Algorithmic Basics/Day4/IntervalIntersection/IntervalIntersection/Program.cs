public class Solution
{
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
    {
        var res = new List<int[]>();
        var first = 0;
        var second = 0;
        while (first < firstList.Length && second < secondList.Length)
        {
            int lo = Math.Max(firstList[first][0], secondList[second][0]);
            int hi = Math.Min(firstList[first][1], secondList[second][1]);
            if (lo <= hi)
            {
                res.Add(new int[] { lo, hi });
            }

            if (firstList[first][1] < secondList[second][1])
            {
                first++;
            }
            else
            {
                second++;
            }
        }

        return res.ToArray();
    }
}