/// <summary>
/// 20220820
/// https://leetcode.cn/problems/maximum-binary-tree/
/// </summary>
public class Solution
{
    public TreeNode ConstructMaximumBinaryTree(int[] nums)
    {
        var root = new TreeNode(nums.Max());
        DFS(root, nums);
        return root;
    }
    public void DFS(TreeNode parent, int[] nums)
    {
        if (nums.Length == 0)
        {
            return;
        }
        var maxIndex = nums.ToList().IndexOf(nums.Max());
        if (maxIndex != 0)
        {
            var leftNums = nums.Take(maxIndex).ToArray();
            if (leftNums.Length == 0)
            {
                return;
            }
            var leftNode = new TreeNode(leftNums.Max());
            parent.left = leftNode;
            DFS(leftNode, leftNums);
        }
        if (maxIndex != nums.Length)
        {
            var rightNums = nums.Skip(maxIndex + 1).Take(nums.Length - maxIndex - 1).ToArray();
            if (rightNums.Length == 0)
            {
                return;
            }
            var rightNode = new TreeNode(rightNums.Max());
            parent.right = rightNode;
            DFS(rightNode, rightNums);
        }
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