/// <summary>
/// 20221031
/// https://leetcode.cn/problems/magical-string/
/// </summary>
public class Solution
{
    public int MagicalString(int n)
    {
        if (n <= 3) return 1;
        int[] arr = new int[n];
        arr[0] = 1; arr[1] = 2; arr[2] = 2;
        int i = 2, j = 3;
        while (j < n)
        {
            switch (arr[i])
            {
                case 1:
                    arr[j] = 3 - arr[j - 1];
                    break;
                case 2:
                    arr[j] = 3 - arr[j - 1];
                    if (++j == n) return ConutOneNumber(arr);
                    arr[j] = arr[j - 1];
                    break;
            }
            i++;
            ++j;
        }
        return ConutOneNumber(arr);
    }
    private int ConutOneNumber(int[] arr) => arr.Count(t => t == 1);
}