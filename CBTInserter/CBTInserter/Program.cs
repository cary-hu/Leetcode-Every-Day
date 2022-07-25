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
/// 20220725
/// https://leetcode.cn/problems/complete-binary-tree-inserter/
/// https://leetcode.cn/problems/NaqhDT/
/// </summary>
public class CBTInserter
{
    private TreeNode _root;
    public CBTInserter(TreeNode root)
    {
        _root = root;
    }

    public int Insert(int val)
    {
        var node = new TreeNode(val);
        if (_root.left == null)
        {
            _root.left = node;
            return _root.val;
        }
        else if (_root.right == null)
        {
            _root.right = node;
            return _root.val;
        }
        else
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(_root);
            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();
                if (cur.left == null)
                {
                    cur.left = node;
                    return cur.val;
                }
                else if (cur.right == null)
                {
                    cur.right = node;
                    return cur.val;
                }
                else
                {
                    queue.Enqueue(cur.left);
                    queue.Enqueue(cur.right);
                }
            }
        }
        return -1;
    }

    public TreeNode Get_root()
    {
        return _root;
    }
}

/**
 * Your CBTInserter object will be instantiated and called as such:
 * CBTInserter obj = new CBTInserter(root);
 * int param_1 = obj.Insert(val);
 * TreeNode param_2 = obj.Get_root();
 */