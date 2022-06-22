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
/// 20220622
/// https://leetcode.cn/problems/find-bottom-left-tree-value/
/// </summary>
public class Solution
{
    public int FindBottomLeftValue(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var res = root.val;
        while (queue.Count > 0)
        {
            var size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                if (i == 0)
                {
                    res = node.val;
                }
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }
        return res;


    }
}