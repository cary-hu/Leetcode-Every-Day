/// <summary>
/// 20220609
/// https://leetcode.cn/problems/random-point-in-non-overlapping-rectangles/
/// </summary>
public class Solution
{
    Random rand;
    IList<int> arr;
    int[][] rects;

    public Solution(int[][] rects)
    {
        rand = new Random();
        arr = new List<int>();
        arr.Add(0);
        this.rects = rects;
        foreach (int[] rect in rects)
        {
            int a = rect[0], b = rect[1], x = rect[2], y = rect[3];
            arr.Add(arr[arr.Count - 1] + (x - a + 1) * (y - b + 1));
        }
    }

    public int[] Pick()
    {
        int k = rand.Next(arr[arr.Count - 1]);
        int rectIndex = BinarySearch(arr, k + 1) - 1;
        k -= arr[rectIndex];
        int[] rect = rects[rectIndex];
        int a = rect[0], b = rect[1], y = rect[3];
        int col = y - b + 1;
        int da = k / col;
        int db = k - col * da;
        return new int[] { a + da, b + db };
    }
    private int BinarySearch(IList<int> arr, int target)
    {
        int low = 0, high = arr.Count - 1;
        while (low <= high)
        {
            int mid = (high - low) / 2 + low;
            int num = arr[mid];
            if (num == target)
            {
                return mid;
            }
            else if (num > target)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return low;
    }
}
