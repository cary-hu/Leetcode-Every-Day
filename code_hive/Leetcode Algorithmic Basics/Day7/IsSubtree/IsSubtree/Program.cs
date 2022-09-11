/// <summary>
/// 20220911
/// https://leetcode.cn/problems/subtree-of-another-tree/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        return DFS(root, subRoot);
    }
    private bool DFS(TreeNode root, TreeNode subRoot)
    {
        if (root == null)
        {
            return false;
        }
        return Check(root, subRoot) || DFS(root.left, subRoot) || DFS(root.right, subRoot);
    }
    private bool Check(TreeNode root, TreeNode subRoot)
    {
        if (root == null && subRoot == null)
        {
            return true;
        }
        if(root == null || subRoot == null || subRoot.val != root.val)
        {
            return false;
        }
        return Check(root.left, subRoot.left) && Check(root.right, subRoot.right);
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