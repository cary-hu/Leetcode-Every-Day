/// <summary>
/// 20220911
/// https://leetcode.cn/problems/populating-next-right-pointers-in-each-node-ii/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public Node Connect(Node root)
    {
        if (root == null)
        {
            return root;
        }
        var queue = new Queue<Node>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var currentLevel = new List<Node>();
            while (queue.Count > 0)
            {
                currentLevel.Add(queue.Dequeue());
            }
            foreach (var item in currentLevel)
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
            for (int i = 0; i < currentLevel.Count - 1; i++)
            {
                currentLevel[i].next = currentLevel[i + 1];
            }
            currentLevel[currentLevel.Count - 1].next = null;
        }

        return root;
    }
}


// Definition for a Node.
public class Node
{
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next)
    {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
