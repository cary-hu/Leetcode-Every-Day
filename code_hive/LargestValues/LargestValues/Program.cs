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
/// 20220624
/// https://leetcode.cn/problems/find-largest-value-in-each-tree-row/
/// </summary>
public class Solution
{
    public IList<int> LargestValues(TreeNode root)
    {
        var res = new List<int>();
        if(root == null)
        {
            return res; 
        }
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        while(q.Count > 0)
        {
            var size = q.Count;
            var max = int.MinValue;
            for (int i = 0; i < size; i++)
            {
                var current = q.Dequeue();
                if (current.val > max)
                {
                    max = current.val;
                }
                if (current.left != null)
                {
                    q.Enqueue(current.left);
                }
                if (current.right != null)
                {
                    q.Enqueue(current.right);
                }
            }
            res.Add(max);
        }
        return res;
    }
}