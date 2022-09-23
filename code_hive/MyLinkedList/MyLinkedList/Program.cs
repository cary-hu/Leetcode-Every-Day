/// <summary>
/// 20220923
/// https://leetcode.cn/problems/design-linked-list/
/// </summary>
public class MyLinkedList
{
    private ListNode Root { get; set; }
    private int Size { get; set; }
    public MyLinkedList()
    {
        Root = new ListNode(-1);
        Size = 0;
    }

    public int Get(int index)
    {
        if (index < 0 || index >= Size)
        {
            return -1;
        }
        ListNode cur = Root;
        for (int i = 0; i <= index; i++)
        {
            cur = cur.next!;
        }
        return cur.val;
    }

    public void AddAtHead(int val)
    {
        AddAtIndex(0, val);
    }

    public void AddAtTail(int val)
    {
        AddAtIndex(Size, val);
    }

    public void AddAtIndex(int index, int val)
    {
        if (index > Size)
        {
            return;
        }
        index = Math.Max(0, index);
        Size++;
        var pred = Root;
        for (int i = 0; i < index; i++)
        {
            pred = pred.next!;
        }
        var toAdd = new ListNode(val)
        {
            next = pred.next
        };
        pred.next = toAdd;
    }

    public void DeleteAtIndex(int index)
    {
        if (index < 0 || index >= Size)
        {
            return;
        }
        Size--;
        var pred = Root;
        for (int i = 0; i < index; i++)
        {
            pred = pred.next!;
        }
        pred.next = pred.next!.next;
    }
}


class ListNode
{
    public int val;
    public ListNode? next;

    public ListNode(int val) => this.val = val;
}

/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */