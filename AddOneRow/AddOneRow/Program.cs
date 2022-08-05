var a = new Solution();
var root = new TreeNode(4, new TreeNode(2, new TreeNode(3), new TreeNode(1)), new TreeNode(6, new TreeNode(5)));
a.AddOneRow(root, 1, 2);


/// <summary>
/// 20220805
/// https://leetcode.cn/problems/add-one-row-to-tree/
/// </summary>
public class Solution
{
    public TreeNode AddOneRow(TreeNode root, int val, int depth)
    {
        if (root == null)
        {
            return new TreeNode(val);
        }
        if (depth == 1)
        {
            return new TreeNode(val, root);
        }
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var level = 1;

        while (queue.Count > 0)
        {
            var currentLevelNode = new List<TreeNode>();
            while (queue.Count > 0)
            {
                currentLevelNode.Add(queue.Dequeue());
            }

            if (level == depth - 1)
            {
                foreach (var item in currentLevelNode)
                {

                    item.left = new TreeNode(val, item.left);
                    item.right = new TreeNode(val, null, item.right);
                }
                break;
            }
            else
            {
                foreach (var item in currentLevelNode)
                {
                    if (item.left != null)
                    {

                        queue.Enqueue(item.left);
                    }
                    if (item.right != null)
                    {

                        queue.Enqueue(item.right);
                    }

                }
            }
            level++;
        }
        return root;
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