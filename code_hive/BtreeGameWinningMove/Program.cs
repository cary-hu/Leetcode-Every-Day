/// <summary>
/// 20230203
/// https://leetcode.cn/problems/binary-tree-coloring-game/
/// </summary>
public class Solution
{
    private int CountLeft = 0;
    private int CountRight = 0;
    public bool BtreeGameWinningMove(TreeNode root, int n, int x)
    {
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var currentRoot = stack.Pop();
            if (currentRoot.val == x)
            {
                if (currentRoot.left != null)
                {
                    CountLeft = DFS(currentRoot.left);
                }
                else
                {
                    CountLeft = 0;
                }
                if (currentRoot.right != null)
                {
                    CountRight = DFS(currentRoot.right);
                }
                else
                {
                    CountRight = 0;
                }
                break;
            }
            if (currentRoot.left != null)
            {
                stack.Push(currentRoot.left);
            }
            if (currentRoot.right != null)
            {
                stack.Push(currentRoot.right);
            }
        }
        var otherNodeCount = n - CountLeft - CountRight - 1;
        if (otherNodeCount == 0)
        {
            return CountLeft + 1 < CountRight || CountRight + 1 < CountLeft;
        }
        else
        {
            return otherNodeCount > (CountRight + CountLeft + 1) ||
                CountRight> (otherNodeCount + CountLeft + 1) ||
                CountLeft> (CountRight + otherNodeCount + 1);
        }
    }
    private int DFS(TreeNode root)
    {
        var count = 1;
        if (root.left != null)
        {
            count += DFS(root.left);
        }
        if (root.right != null)
        {
            count += DFS(root.right);
        }
        return count;
    }
}

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