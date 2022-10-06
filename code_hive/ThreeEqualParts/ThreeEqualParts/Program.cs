new Solution().ThreeEqualParts(new int[] { 0,1,0,1,1 });
/// <summary>
/// 20221006
/// https://leetcode.cn/problems/three-equal-parts/
/// </summary>
public class Solution
{
    public int[] ThreeEqualParts(int[] arr)
    {
        var res = new int[] { -1, -1 };
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length - i; j++)
            {
                if (IsEqualParts(arr, i, j))
                {
                    res[0] = i;
                    res[1] = j + 1;
                }
            }
        }

        return res;
    }
    private bool IsEqualParts(int[] arr, int start, int end)
    {
        var first = Convert.ToInt32(string.Join("", arr.Take(start + 1)), 2);
        var second = Convert.ToInt32(string.Join("", arr.Skip(start + 1).Take(end - start - 1)), 2);
        var third = Convert.ToInt32(string.Join("", arr.Skip(end + 1).Take(arr.Length - end)), 2);
        return first == second && second == third;
    }
}