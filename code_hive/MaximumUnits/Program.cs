/// <summary>
/// 20221115
/// https://leetcode.cn/problems/maximum-units-on-a-truck/
/// </summary>
public class Solution
{
    public int MaximumUnits(int[][] boxTypes, int truckSize)
    {
        var res = 0;
        Array.Sort(boxTypes, (a, b) => { return b[1] - a[1]; });
        foreach (var box in boxTypes)
        {
            int numberOfBoxes = box[0];
            int numberOfUnitsPerBox = box[1];
            if (numberOfBoxes < truckSize)
            {
                res += numberOfBoxes * numberOfUnitsPerBox;
                truckSize -= numberOfBoxes;
            }
            else
            {
                res += truckSize * numberOfUnitsPerBox;
                break;
            }
        }

        return res;
    }
}