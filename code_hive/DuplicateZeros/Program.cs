/// <summary>
/// 20220617
/// https://leetcode.cn/problems/duplicate-zeros/
/// </summary>
public class Solution
{
    public void DuplicateZeros(int[] arr)
    {
        int n = arr.Length;
        int top = 0;
        int i = -1;
        while (top < n)
        {
            i++;
            if (arr[i] != 0)
            {
                top++;
            }
            else
            {
                top += 2;
            }
        }
        int j = n - 1;
        if (top == n + 1)
        {
            arr[j] = 0;
            j--;
            i--;
        }
        while (j >= 0)
        {
            arr[j] = arr[i];
            j--;
            if (arr[i] == 0)
            {
                arr[j] = arr[i];
                j--;
            }
            i--;
        }
    }
}