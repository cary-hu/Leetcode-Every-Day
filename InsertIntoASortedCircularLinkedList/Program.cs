var head = new Node(3);
var secound = new Node(5);
var third = new Node(1);
head.next = secound;
secound.next = third;
third.next = head;
var a = new Solution();
a.Insert(head, 0);
/// <summary>
/// 20220618
/// https://leetcode.cn/problems/4ueAj6/
/// </summary>
public class Solution
{
    public Node Insert(Node head, int insertVal)
    {
        Node node = new Node(insertVal);
        if (head == null)
        {
            node.next = node;
            return node;
        }
        if (head.next == head)
        {
            head.next = node;
            node.next = head;
            return head;
        }
        Node cur = head, next = head.next;
        while (next != head)
        {
            if (insertVal >= cur.val && insertVal <= next.val)
            {
                break;
            }
            if (cur.val > next.val)
            {
                if (insertVal > cur.val || insertVal < next.val)
                {
                    break;
                }
            }
            cur = cur.next;
            next = next.next;
        }

        cur.next = node;
        node.next = next;
        return head;
    }
}

// Definition for a Node.
public class Node
{
    public int val;
    public Node next;
    public Node() { }
    public Node(int _val)
    {
        val = _val;
        next = null;
    }
    public Node(int _val, Node _next)
    {
        val = _val;
        next = _next;
    }
}