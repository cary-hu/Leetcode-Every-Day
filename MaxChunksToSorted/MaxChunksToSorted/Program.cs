/// <summary>
/// 20220813
/// https://leetcode.cn/problems/max-chunks-to-make-sorted-ii/
/// </summary>
public class Solution
{
    public int MaxChunksToSorted(int[] arr)
    {
        var stack = new Stack<int>();
        for (int i = 0; i < arr.Length; i++)
        {
            int element = arr[i];
            if (stack.Count > 0)
            {
                element = Math.Max(arr[i], stack.Peek());
            }
            while(stack.Count > 0 && arr[i] < stack.Peek())
            {
                stack.Pop();
            }
            stack.Push(element);
        }
        return stack.Count;
    }
}