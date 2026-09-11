/// <summary>
/// 20260911
/// https://leetcode.cn/problems/unique-3-digit-even-numbers/
/// You are given an array of digits called digits. Your task is to determine the number of distinct three-digit even numbers that can be formed using these digits.
/// Note: Each copy of a digit can only be used once per number, and there may not be leading zeros.
/// </summary>
public class Solution
{
    public int TotalNumbers(int[] digits)
    {
        int[] frequency = new int[10];
        foreach (int digit in digits)
        {
            frequency[digit]++;
        }

        int distinctDigits = frequency.Count(count => count > 0);
        int total = 0;

        for (int units = 0; units <= 8; units += 2)
        {
            if (frequency[units] == 0)
            {
                continue;
            }

            for (int hundreds = 1; hundreds <= 9; hundreds++)
            {
                if (frequency[hundreds] == 0 ||
                    (hundreds == units && frequency[hundreds] < 2))
                {
                    continue;
                }

                int availableTens = distinctDigits;

                if (hundreds == units)
                {
                    availableTens -= frequency[hundreds] == 2 ? 1 : 0;
                }
                else
                {
                    availableTens -= frequency[hundreds] == 1 ? 1 : 0;
                    availableTens -= frequency[units] == 1 ? 1 : 0;
                }

                total += availableTens;
            }
        }

        return total;
    }
}
