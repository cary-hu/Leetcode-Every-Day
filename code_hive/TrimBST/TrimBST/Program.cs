var a = new Solution();
a.TrimBST(new TreeNode(1, new TreeNode(0), new TreeNode(2)), 1, 2);
/// <summary>
/// 20220910
/// https://leetcode.cn/problems/trim-a-binary-search-tree/
/// </summary>
public class Solution
{
    public TreeNode TrimBST(TreeNode root, int low, int high)
    {
        DFS(root, low, high);
        return root;
    }

    private void DFS(TreeNode root, int low, int high)
    {
        if (root.val < low || root.val > high)
        {
            Remove(root, root.val);
        }
        DFS(root.left, low, high);
        DFS(root.right, low, high);
    }
    private void Remove(TreeNode root, int val)
    {
        if (root == null)
        {
            return;
        }
        var cur = root;
        TreeNode parent = null;
        while (cur != null)
        {
            if (val > cur.val)
            {
                parent = cur;
                cur = cur.right;
            }
            else if (val < cur.val)
            {
                parent = cur;
                cur = cur.left;
            }
            else
            {
                RemoveNode(parent, cur);
            }
        }
    }
    private void RemoveNode(TreeNode root, TreeNode cur)
    {
        if (cur.left == null)
        {
            if (cur == root)
            {
                root = cur.right;
            }
            if (cur == root?.left)
            {
                root.left = cur.right;
            }
            if (cur == root?.right)
            {
                root.right = cur.right;
            }
        }
        else if (cur.right == null)
        {
            if (cur == root)
            {
                root = cur.left;
            }
            if (cur == root?.left)
            {
                root.left = cur.left;
            }
            if (cur == root?.right)
            {
                root.right = cur.right;
            }
        }
        else
        {
            var targetNode = cur.right;
            var targetParentNode = cur;
            while (targetNode.left != null)
            {
                targetParentNode = targetNode;
                targetNode = targetNode.left;
            }
            cur.val = targetNode.val;
            if (targetNode == targetParentNode.left)
            {
                targetParentNode.left = targetNode.right;
            }
            else
            {
                targetParentNode.right = targetNode.right;
            }
        }
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
