/// <summary>
/// 20220905
/// https://leetcode.cn/problems/find-duplicate-subtrees/
/// </summary>
public class Solution
{
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
    {
        var dictionary = new Dictionary<string, int>();
        var res = new List<TreeNode>();
        DFS(root, res, dictionary);
        return res;
    }
    private string DFS(TreeNode root, List<TreeNode> res, Dictionary<string, int> mp)
    {
        string str;
        if (root == null) return "#";
        str = root.val.ToString() + ' ' + DFS(root.left, res, mp) + ' ' + DFS(root.right, res, mp);
        if (mp.ContainsKey(str))
        {
            if (mp[str] == 1) res.Add(root);
            mp[str]++;
        } else
        {
            mp.Add(str, 1);
        }
        return str;
    }
}

// Definition for a binary tree node.
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