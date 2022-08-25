var a = new Solution();
a.FindClosestElements(new int[] { -2, -1, 1, 2, 3, 4, 5 }, 7, 3);
/// <summary>
/// 20220825
/// https://leetcode.cn/problems/find-k-closest-elements/
/// </summary>
public class Solution
{
    public IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        Array.Sort(arr, (a, b) =>
        {
            if (Math.Abs(a - x) != Math.Abs(b - x))
            {
                return Math.Abs(a - x) - Math.Abs(b - x);
            }
            else
            {
                return a - b;
            }
        });
        int[] closest = arr.Take(k).ToArray();
        Array.Sort(closest);
        IList<int> ans = new List<int>();
        foreach (int num in closest)
        {
            ans.Add(num);
        }
        return ans;
    }
}