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
/// 20220716
/// https://leetcode.cn/problems/same-tree/
/// </summary>
public class Solution
{
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == null && q == null)
        {
            return true;
        }
        if (p == null || q == null)
        {
            return false;
        }
        var qp = new Queue<TreeNode>();
        var qq = new Queue<TreeNode>();
        qp.Enqueue(p);
        qq.Enqueue(q);
        while (qp.Count > 0 && qq.Count > 0)
        {
            var pn = qp.Dequeue();
            var qn = qq.Dequeue();
            if (pn.val != qn.val)
            {
                return false;
            }
            if (pn.left != null && qn.left != null)
            {
                qp.Enqueue(pn.left);
                qq.Enqueue(qn.left);
            }
            else if (pn.left == null && qn.left != null)
            {
                return false;
            }
            else if (pn.left != null && qn.left == null)
            {
                return false;
            }
            if (pn.right != null && qn.right != null)
            {
                qp.Enqueue(pn.right);
                qq.Enqueue(qn.right);
            }
            else if (pn.right == null && qn.right != null)
            {
                return false;
            }
            else if (pn.right != null && qn.right == null)
            {
                return false;
            }
        }

        return true;
    }
    public bool IsSameTreeDFS(TreeNode p, TreeNode q)
    {
        if (p == null && q == null)
        {
            return true;
        }
        if (p == null || q == null)
        {
            return false;
        }
        if (q.val != p.val)
        {
            return false;
        }
        return IsSameTreeDFS(p.left, q.left) && IsSameTreeDFS(p.right, q.right);

    }
}