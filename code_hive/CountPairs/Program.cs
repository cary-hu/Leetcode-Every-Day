/// <summary>
/// 20220105
/// https://leetcode.cn/problems/count-pairs-with-xor-in-a-range/
/// </summary>
public class Solution
{
    // 字典树的根节点
    private Trie root = null;
    // 最高位的二进制位编号为 14
    private const int HIGH_BIT = 14;

    public int CountPairs(int[] nums, int low, int high)
    {
        return F(nums, high) - F(nums, low - 1);
    }

    public int F(int[] nums, int x)
    {
        root = new Trie();
        int res = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            Add(nums[i - 1]);
            res += Get(nums[i], x);
        }
        return res;
    }

    public void Add(int num)
    {
        Trie cur = root;
        for (int k = HIGH_BIT; k >= 0; k--)
        {
            int bit = (num >> k) & 1;
            if (cur.son[bit] == null)
            {
                cur.son[bit] = new Trie();
            }
            cur = cur.son[bit];
            cur.sum++;
        }
    }

    public int Get(int num, int x)
    {
        Trie cur = root;
        int sum = 0;
        for (int k = HIGH_BIT; k >= 0; k--)
        {
            int r = (num >> k) & 1;
            if (((x >> k) & 1) != 0)
            {
                if (cur.son[r] != null)
                {
                    sum += cur.son[r].sum;
                }
                if (cur.son[r ^ 1] == null)
                {
                    return sum;
                }
                cur = cur.son[r ^ 1];
            }
            else
            {
                if (cur.son[r] == null)
                {
                    return sum;
                }
                cur = cur.son[r];
            }
        }
        sum += cur.sum;
        return sum;
    }
}

class Trie
{
    // son[0] 表示左子树，son[1] 表示右子树
    public Trie[] son = new Trie[2];
    public int sum;

    public Trie()
    {
        sum = 0;
    }
}