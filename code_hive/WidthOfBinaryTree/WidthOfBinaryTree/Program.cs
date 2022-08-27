/// <summary>
/// 20220827
/// https://leetcode.cn/problems/maximum-width-of-binary-tree/
/// </summary>
public class Solution
{
    Dictionary<int, int> levelMin = new Dictionary<int, int>();

    public int WidthOfBinaryTree(TreeNode root)
    {
        return DFS(root, 1, 1);
    }

    public int DFS(TreeNode node, int depth, int index)
    {
        if (node == null)
        {
            return 0;
        }
        levelMin.TryAdd(depth, index); // 每一层最先访问到的节点会是最左边的节点，即每一层编号的最小值
        return Math.Max(index - levelMin[depth] + 1, Math.Max(DFS(node.left, depth + 1, index * 2), DFS(node.right, depth + 1, index * 2 + 1)));
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