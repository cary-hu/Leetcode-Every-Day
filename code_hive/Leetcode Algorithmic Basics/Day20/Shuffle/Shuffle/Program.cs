/// <summary>
/// 20220924
/// https://leetcode.cn/problems/shuffle-an-array/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    private Random RandomP { get; set; } = new Random();

    private int[] Nums { get; set; }
    public Solution(int[] nums)
    {
        Nums = nums;
    }

    public int[] Reset()
    {
        return Nums;
    }

    public int[] Shuffle()
    {
        var res = new List<int>(Nums);
        for (int i = 0; i < res.Count; i++)
        {
            int randomIndex = RandomP.Next() % res.Count;
            if(randomIndex != i)
            {
                (res[i], res[randomIndex]) = (res[randomIndex], res[i]);
            }

        }
        return res.ToArray();
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int[] param_1 = obj.Reset();
 * int[] param_2 = obj.Shuffle();
 */