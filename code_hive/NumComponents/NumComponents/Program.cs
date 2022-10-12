/// <summary>
/// 20221012
/// https://leetcode.cn/problems/linked-list-components/
/// </summary>
/// 
new Solution().NumComponents(new ListNode(0, new ListNode(1, new ListNode(2, new ListNode(3)))), new int[] { 0, 1, 3 });
public class Solution
{
    public int NumComponents(ListNode head, int[] nums)
    {
        int ans = 0;
        var cur = head;
        while (cur != null)
        {
            if (nums.Contains(cur.val))
            {
                ans++;
                while (cur != null)
                {
                    if(nums.Contains(cur.val))
                    {
                        cur = cur.next;
                    } else
                    {
                        break;
                    }
                }
            }
            else
            {
                cur = cur.next;
            }
        }

        return ans;
    }
}


//Definition for singly-linked list.
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
