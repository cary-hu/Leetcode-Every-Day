﻿/// <summary>
/// 20220830
/// https://leetcode.cn/problems/maximum-binary-tree-ii/
/// </summary>
public class Solution
{
    public TreeNode InsertIntoMaxTree(TreeNode root, int val)
    {
        if (root == null)
        {
            return new TreeNode(val);
        }
        if (root.val < val)
        {
            return new TreeNode(val, root);
        }
        root.right = InsertIntoMaxTree(root.right, val);
        return root;
    }
}

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