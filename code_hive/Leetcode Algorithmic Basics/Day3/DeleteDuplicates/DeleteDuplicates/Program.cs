
var a = new Solution();
a.DeleteDuplicates(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(3, new ListNode(4, new ListNode(4, new ListNode(5))))))));
/// <summary>
/// 20220907
/// https://leetcode.cn/problems/remove-duplicates-from-sorted-list-ii/
/// </summary>
public class Solution
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        var dummy = new ListNode(0, head);
        var p = dummy;
        while (p.next != null)
        {
            var q = p.next;
            while (q != null && q.val == p.next.val)
            {
                q = q.next;
            }
            if (p.next.next == q)
            {
                p = p.next;
            }
            else
            {
                p.next = q;
            }
        }
        return dummy.next;
    }
}

// Definition for singly - linked list.
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}