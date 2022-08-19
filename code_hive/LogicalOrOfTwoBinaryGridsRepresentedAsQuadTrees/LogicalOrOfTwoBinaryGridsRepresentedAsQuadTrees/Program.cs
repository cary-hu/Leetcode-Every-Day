// Definition for a QuadTree node.
public class Node
{
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node() { }
    public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
    {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}

/// <summary>
/// 20220715
/// https://leetcode.cn/problems/logical-or-of-two-binary-grids-represented-as-quad-trees/
/// </summary>
public class Solution
{
    public Node Intersect(Node quadTree1, Node quadTree2)
    {
        if ((quadTree1.isLeaf && quadTree1.val) || (quadTree2.isLeaf && !quadTree2.val))
        {
            return quadTree1;
        }
        else if ((quadTree2.isLeaf && quadTree2.val) || (quadTree1.isLeaf && !quadTree1.val))
        {
            return quadTree2;
        }
        else
        {
            var lt = Intersect(quadTree1.topLeft, quadTree2.topLeft);
            var rt = Intersect(quadTree1.topRight, quadTree2.topRight);
            var lb = Intersect(quadTree1.bottomLeft, quadTree2.bottomLeft);
            var rb = Intersect(quadTree1.bottomRight, quadTree2.bottomRight);
            if (lt.isLeaf && rt.isLeaf && lb.isLeaf && rb.isLeaf && lt.val == rt.val && lt.val == lb.val && lt.val == rb.val)
            {
                return lt;
            }
            return new Node(false, false, lt, rt, lb, rb);
        }
    }
}