/// <summary>
/// 20220815
/// https://leetcode.cn/problems/design-circular-deque/
/// </summary>
public class MyCircularDeque
{
    private int[] _queue { get; set; }
    private int rear { get; set; } = 0;
    private int front { get; set; } = 0;
    private int capacity { get; set; }

    public MyCircularDeque(int k)
    {
        _queue = new int[k + 1];
        capacity = k + 1;
    }

    public bool InsertFront(int value)
    {
        if (IsFull())
        {
            return false;
        }
        front = (front - 1 + capacity) % capacity;
        _queue[front] = value;
        return true;
    }

    public bool InsertLast(int value)
    {
        if (IsFull())
        {
            return false;
        }
        _queue[rear] = value;
        rear = (rear + 1) % capacity;
        return true;
    }

    public bool DeleteFront()
    {
        if (IsEmpty())
        {
            return false;
        }
        front = (front + 1) % capacity;
        return true;
    }

    public bool DeleteLast()
    {
        if (IsEmpty())
        {
            return false;
        }
        rear = (rear - 1 + capacity) % capacity;
        return true;
    }

    public int GetFront()
    {
        if (IsEmpty())
        {
            return -1;
        }
        return _queue[front];
    }

    public int GetRear()
    {
        if (IsEmpty())
        {
            return -1;
        }
        return _queue[(rear - 1 + capacity) % capacity];
    }

    public bool IsEmpty()
    {
        return front == rear;
    }

    public bool IsFull()
    {
        return front == (rear + 1) % capacity;
    }
}

/**
 * Your MyCircularDeque object will be instantiated and called as such:
 * MyCircularDeque obj = new MyCircularDeque(k);
 * bool param_1 = obj.InsertFront(value);
 * bool param_2 = obj.InsertLast(value);
 * bool param_3 = obj.DeleteFront();
 * bool param_4 = obj.DeleteLast();
 * int param_5 = obj.GetFront();
 * int param_6 = obj.GetRear();
 * bool param_7 = obj.IsEmpty();
 * bool param_8 = obj.IsFull();
 */