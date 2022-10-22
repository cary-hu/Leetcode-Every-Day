/// <summary>
/// 20221019
/// https://leetcode.cn/problems/number-of-students-unable-to-eat-lunch/
/// Sadly, Forgot commit code.
/// </summary>
public class Solution
{
    public int CountStudents(int[] students, int[] sandwiches)
    {
        var queue = new Queue<int>(students);
        var stack = new Stack<int>(sandwiches.Reverse());
        var count = 0;
        while (stack.Count > 0)
        {
            if (count == queue.Count)
            {
                break;
            }
            var currentStudent = queue.Dequeue();
            if (stack.Peek() == currentStudent)
            {
                stack.Pop();
                count = 0;
            }
            else
            {
                queue.Enqueue(currentStudent);
                count++;
            }
        }
        return queue.Count;
    }
}
