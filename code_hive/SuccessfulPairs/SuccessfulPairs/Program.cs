/// <summary>
/// 20231110
/// https://leetcode.cn/problems/successful-pairs-of-spells-and-potions/description/?envType=daily-question&envId=2023-11-10
/// </summary>
public class Solution
{
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        var res = new int[spells.Length];
        Array.Fill(res, 0);
        Array.Sort(potions);
        for (int i = 0; i < spells.Length; i++)
        {
            var potionIndex = BSearch(0, potions.Length - 1, spells[i], potions, success);
            res[i] = potions.Length - potionIndex;
        }
        return res;
    }
    private static int BSearch(int l, int r, int spell, int[] potions, long success)
    {
        long t = (success + spell - 1) / spell - 1;

        var res = r + 1;
        while (l <= r)
        {
            int mid = l + ((r - l) >> 1);
            if (potions[mid] > t)
            {
                res = mid;
                r = mid - 1;
            }
            else l = mid + 1;
        }
        return res;
    }
}