/// <summary>
/// 20220902
/// https://leetcode.cn/problems/longest-univalue-path/
/// </summary>
public class Solution
{
    private int _max = 0;
    public int LongestUnivaluePath(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }
        DFS(root, root.val);
        return _max;
    }

    public int DFS(TreeNode root, int val)
    {
        if (root == null)
        {
            return 0;
        }
        var left = DFS(root.left, root.val);
        var right = DFS(root.right, root.val);
        _max = Math.Max(_max, left + right);
        if (root.val == val)
        {
            return Math.Max(left, right) + 1;
        }
        return 0;
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
