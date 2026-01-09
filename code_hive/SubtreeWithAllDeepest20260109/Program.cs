//Definition for a binary tree node.
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
/// <summary>
/// 20260109
/// https://leetcode.cn/problems/smallest-subtree-with-all-the-deepest-nodes/
/// </summary>
public class Solution
{
    public TreeNode SubtreeWithAllDeepest(TreeNode root)
    {
        return Dfs(root).Node;
    }
    private (int Depth, TreeNode Node) Dfs(TreeNode node)
    {
        if (node == null)
        {
            return (0, null);
        }

        var left = Dfs(node.left);
        var right = Dfs(node.right);

        if (left.Depth > right.Depth)
        {
            return (left.Depth + 1, left.Node);
        }
        else if (right.Depth > left.Depth)
        {
            return (right.Depth + 1, right.Node);
        }
        else
        {
            return (left.Depth + 1, node);
        }
    }
}