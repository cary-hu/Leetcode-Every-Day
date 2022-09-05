/// <summary>
/// 20220905
/// https://leetcode.cn/problems/search-a-2d-matrix/
/// </summary>
public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var res = false;
        foreach (var item in matrix)
        {
            if (item.First() > target || item.Last() < target)
            {
                continue;
            }
            var l = 0;
            var r = item.Length - 1;
            while(l < r)
            {
                var mid = (l + r) >> 1;
                if (item[mid] >= target)
                {
                    r = mid;
                } else
                {
                    l = mid + 1;
                }
            }
            if (item[l] == target)
            {
                res = true;
            }
        }
        return res;
    }
}