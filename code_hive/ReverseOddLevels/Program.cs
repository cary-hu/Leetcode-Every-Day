/// <summary>
/// 20231215
/// https://leetcode.cn/problems/reverse-odd-levels-of-binary-tree/
/// </summary>
public class Solution
{
    public TreeNode ReverseOddLevels(TreeNode root)
    {
        var res = new TreeNode(root.val, root.left, root.right);
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        var needHandle = false;
        while (q.Count > 0)
        {
            var currentLevelTreeNodes = new List<TreeNode>();
            var currentLevelTreeNodesValue = new List<int>();
            while (q.Count > 0)
            {
                var treeItem = q.Dequeue();
                currentLevelTreeNodes.Add(treeItem);
                currentLevelTreeNodesValue.Add(treeItem.val);
            }
            foreach (var treeNodeItem in currentLevelTreeNodes)
            {
                if (treeNodeItem.left != null)
                {
                    q.Enqueue(treeNodeItem.left);
                }
                if (treeNodeItem.right != null)
                {
                    q.Enqueue(treeNodeItem.right);
                }
            }
            if (needHandle)
            {
                currentLevelTreeNodesValue.Reverse();
                for (int i = 0; i < currentLevelTreeNodes.Count; i++)
                {
                    currentLevelTreeNodes[i].val = currentLevelTreeNodesValue[i];
                }
            }
            needHandle = !needHandle;
        }

        return res;
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