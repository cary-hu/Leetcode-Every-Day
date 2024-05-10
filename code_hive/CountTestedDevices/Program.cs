/// <summary>
/// 20240510
/// https://leetcode.cn/problems/count-tested-devices-after-test-operations/
/// </summary>
public class Solution
{
    public int CountTestedDevices(int[] batteryPercentages)
    {
        var length = batteryPercentages.Length;
        var result = 0;
        for (int i = 0; i < length; i++)
        {
            if (batteryPercentages[i] <= 0)
            {
                continue;
            }
            result++;
            for (int j = i + 1; j < batteryPercentages.Length; j++)
            {
                batteryPercentages[j] = Math.Max(0, batteryPercentages[j] - 1);
            }
        }
        return result;
    }
}