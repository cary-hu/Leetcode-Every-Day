/// <summary>
/// 20220822
/// https://leetcode.cn/problems/print-binary-tree/
/// </summary>
public class Solution
{
    public IList<IList<string>> PrintTree(TreeNode root)
    {
        int height = CalDepth(root);
        int m = height + 1;
        int n = (1 << (height + 1)) - 1;
        IList<IList<string>> res = new List<IList<string>>();
        for (int i = 0; i < m; i++)
        {
            IList<string> row = new List<string>();
            for (int j = 0; j < n; j++)
            {
                row.Add("");
            }
            res.Add(row);
        }
        Queue<Tuple<TreeNode, int, int>> queue = new Queue<Tuple<TreeNode, int, int>>();
        queue.Enqueue(new Tuple<TreeNode, int, int>(root, 0, (n - 1) / 2));
        while (queue.Count > 0)
        {
            Tuple<TreeNode, int, int> t = queue.Dequeue();
            TreeNode node = t.Item1;
            int r = t.Item2, c = t.Item3;
            res[r][c] = node.val.ToString();
            if (node.left != null)
            {
                queue.Enqueue(new Tuple<TreeNode, int, int>(node.left, r + 1, c - (1 << (height - r - 1))));
            }
            if (node.right != null)
            {
                queue.Enqueue(new Tuple<TreeNode, int, int>(node.right, r + 1, c + (1 << (height - r - 1))));
            }
        }
        return res;
    }

    public int CalDepth(TreeNode root)
    {
        int res = -1;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            int len = queue.Count;
            res++;
            while (len > 0)
            {
                len--;
                TreeNode t = queue.Dequeue();
                if (t.left != null)
                {
                    queue.Enqueue(t.left);
                }
                if (t.right != null)
                {
                    queue.Enqueue(t.right);
                }
            }
        }
        return res;
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