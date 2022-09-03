/// <summary>
/// 20220831
/// https://leetcode.cn/problems/validate-stack-sequences/
/// </summary>
public class Solution
{
    public bool ValidateStackSequences(int[] pushed, int[] popped)
    {
        var stack = new Stack<int>();
        stack.Push(pushed[0]);
        var pushIndex = 1;
        var popIndex = 0;
        while (true)
        {
            if (stack.Count > 0)
            {
                var head = stack.Peek();
                if (head == popped[popIndex])
                {
                    stack.Pop();
                    popIndex++;
                    continue;
                }
            }
            if (pushIndex == pushed.Length)
            {
                break;
            }
            stack.Push(pushed[pushIndex++]);
        }
        if (pushIndex != pushed.Length || popIndex != popped.Length || stack.Count > 0)
        {
            return false;
        }
        return true;
    }
}