public class Solution
{
    public int TemperatureTrend(int[] temperatureA, int[] temperatureB)
    {
        var res = 0;
        var days = temperatureA.Length;
        var currentRes = 0;
        for (int i = 1; i < days; i++)
        {

            if ((temperatureA[i] < temperatureA[i - 1] && temperatureB[i] < temperatureB[i - 1]) ||
                (temperatureA[i] > temperatureA[i - 1] && temperatureB[i] > temperatureB[i - 1]) ||
                temperatureA[i] == temperatureA[i - 1] && temperatureB[i] == temperatureB[i - 1])
            {
                currentRes++;
                res = Math.Max(res, currentRes);
            }
            else
            {
                currentRes = 0;
            }
        }

        return res;
    }
}