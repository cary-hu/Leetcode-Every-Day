/// <summary>
/// 20220619
/// https://leetcode.cn/problems/most-frequent-subtree-sum/
/// </summary>
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public int[] FindFrequentTreeSum(TreeNode root)
    {
        if (root == null)
        {
            return new int[0];
        }
        Dictionary<int, int> dict = new Dictionary<int, int>();
        GetSubTreeSum(root, dict);
        return dict.Where(x => x.Value == dict.Values.Max()).Select(x => x.Key).ToArray();

    }
    private int GetSubTreeSum(TreeNode root, Dictionary<int, int> dict)
    {

        int sum = 0;

        if (root == null)
        {
            return sum;
        }
        sum += root.val;
        sum += GetSubTreeSum(root.left, dict);
        sum += GetSubTreeSum(root.right, dict);
        if (dict.ContainsKey(sum))
        {
            dict[sum]++;
        }
        else
        {
            dict.Add(sum, 1);
        }
        return sum;
    }
}