public class DinnerPlates
{
    private int capacity;
    private Dictionary<int, LinkedList<int>> stacks;
    private SortedSet<int> nonFullStacks;

    public DinnerPlates(int capacity)
    {
        this.capacity = capacity;
        this.stacks = new Dictionary<int, LinkedList<int>>();
        this.nonFullStacks = new SortedSet<int>();
    }

    public void Push(int val)
    {
        int index;
        if (nonFullStacks.Count == 0)
        {
            index = stacks.Count;
            stacks[index] = new LinkedList<int>();
        }
        else
        {
            index = nonFullStacks.Min;
        }
        stacks[index].AddLast(val);
        if (stacks[index].Count == capacity)
        {
            nonFullStacks.Remove(index);
        }
        else
        {
            nonFullStacks.Add(index);
        }
    }

    public int Pop()
    {
        if (stacks.Count == 0)
        {
            return -1;
        }
        var lastStack = stacks[stacks.Count - 1];
        while (lastStack.Count > 0 && lastStack.Last.Value == 0)
        {
            lastStack.RemoveLast();
        }
        if (lastStack.Count == 0)
        {
            stacks.Remove(stacks.Count - 1);
            nonFullStacks.Remove(stacks.Count);
            return Pop();
        }
        nonFullStacks.Add(stacks.Count - 1);
        int result = lastStack.Last.Value;
        lastStack.RemoveLast();
        return result;
    }

    public int PopAtStack(int index)
    {
        if (!stacks.ContainsKey(index) || stacks[index].Count == 0)
        {
            return -1;
        }
        var stack = stacks[index];
        while (stack.Count > 0 && stack.Last.Value == 0)
        {
            stack.RemoveLast();
        }
        if (index == stacks.Count - 1)
        {
            nonFullStacks.Add(stacks.Count - 1);
        }
        else if (!nonFullStacks.Contains(index))
        {
            nonFullStacks.Add(index);
        }
        int result = stack.Last.Value;
        stack.RemoveLast();
        return result;
    }
}