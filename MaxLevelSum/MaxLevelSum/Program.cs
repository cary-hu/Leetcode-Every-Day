
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
/// 20220731
/// https://leetcode.cn/problems/maximum-level-sum-of-a-binary-tree/
/// </summary>
public class Solution
{
    public int MaxLevelSum(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var maxValue = int.MinValue;
        var level = 0;
        var currentLevel = 1;
        while(queue.Count > 0)
        {
            var queueLength = queue.Count;
            var currentLevelSum = 0;
            for (int i = 0; i < queueLength; i++)
            {
                var node = queue.Dequeue();
                if(node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if(node.right != null)
                {
                    queue.Enqueue(node.right);
                }
                currentLevelSum += node.val;
            }
            if(currentLevelSum > maxValue)
            {
                maxValue = currentLevelSum;
                level = currentLevel;
            }
            currentLevel++;
        }
        return level;
    }
}