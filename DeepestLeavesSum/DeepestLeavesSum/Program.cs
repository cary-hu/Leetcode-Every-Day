var root = new TreeNode(1, new TreeNode(2, new TreeNode(4, new TreeNode(7), null), new TreeNode(5)), new TreeNode(3, null, new TreeNode(6, null, new TreeNode(8))));
var a = new Solution();
a.DeepestLeavesSum(root);
/// <summary>
/// 20220817
/// https://leetcode.cn/problems/deepest-leaves-sum/
/// </summary>
public class Solution
{
    public int DeepestLeavesSum(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var sum = root.val;
        while (queue.Count > 0)
        {
            var waitingForAdd = new List<TreeNode>();
            while (queue.Count > 0)
            {
                var currentRoot = queue.Dequeue();
                if (currentRoot.left != null)
                {
                    waitingForAdd.Add(currentRoot.left);
                }
                if (currentRoot.right != null)
                {
                    waitingForAdd.Add(currentRoot.right);
                }
            }
            if (waitingForAdd.Count > 0)
            {
                sum = waitingForAdd.Sum(x => x.val);
            }
            else
            {
                break;
            }
            foreach (var item in waitingForAdd)
            {
                queue.Enqueue(item);
            }
        }
        return sum;

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