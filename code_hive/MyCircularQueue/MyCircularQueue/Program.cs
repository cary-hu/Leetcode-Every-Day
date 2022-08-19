/// <summary>
/// 20220802
/// https://leetcode.cn/problems/design-circular-queue/
/// </summary>
public class MyCircularQueue
{
    private int[] _val { get; set; }
    private int front { get; set; } = 0;
    private int rear { get; set; } = 0;
    private int size { get; set; }

    public MyCircularQueue(int k)
    {
        size = k + 1;
        _val = new int[k + 1];
    }

    public bool EnQueue(int value)
    {
        if(IsFull())
        {
            return false;
        }
        var index = (rear + 1) % size;
        _val[index] = value;
        rear = index;
        return true;
    }

    public bool DeQueue()
    {
        if(IsEmpty())
        {
            return false;
        }
        front = (front + 1) % size;
        return true;
    }

    public int Front()
    {
        if (IsEmpty())
        {
            return -1;
        }
        return _val[(front + 1) % size];
    }

    public int Rear()
    {
        if (IsEmpty())
        {
            return -1;
        }
        return _val[rear];
    }

    public bool IsEmpty()
    {
        return front == rear;
    }

    public bool IsFull()
    {
        return (rear + 1) % size == front;
    }
}

/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */