/// <summary>
/// 20240223
/// https://leetcode.cn/problems/kth-largest-sum-in-a-binary-tree/
/// </summary>
public class Solution
{
    public long KthLargestLevelSum(TreeNode root, int k)
    {
        var sumList = new List<long>();
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        while (q.Count > 0)
        {
            var currentSum = 0L;
            var list = new List<TreeNode>();
            while (q.Count > 0)
            {
                list.Add(q.Dequeue());
            }
            foreach (var item in list)
            {
                if (item.left != null)
                {
                    q.Enqueue(item.left);
                }
                if (item.right != null)
                {
                    q.Enqueue(item.right);
                }
                currentSum += item.val;
            }
            sumList.Add(currentSum);
        }
        if (k > sumList.Count)
        {
            return -1;
        }
        return sumList.OrderByDescending(x => x).ToList()[k-1];
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
