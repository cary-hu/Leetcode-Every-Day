/// <summary>
/// 20220913
/// https://leetcode.cn/problems/maximum-swap/
/// </summary>
public class Solution
{
    public int MaximumSwap(int num)
    {
        char[] charArray = num.ToString().ToCharArray();
        int n = charArray.Length;
        int maxNum = num;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                Swap(charArray, i, j);
                maxNum = Math.Max(maxNum, int.Parse(new string(charArray)));
                Swap(charArray, i, j);
            }
        }
        return maxNum;
    }

    public void Swap(char[] charArray, int i, int j)
    {
        char temp = charArray[i];
        charArray[i] = charArray[j];
        charArray[j] = temp;
    }
}