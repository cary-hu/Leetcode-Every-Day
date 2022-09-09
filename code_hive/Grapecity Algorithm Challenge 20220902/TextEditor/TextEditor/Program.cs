/// <summary>
/// 20220902
/// https://leetcode.cn/problems/design-a-text-editor/
/// </summary>
public class TextEditor
{

    private Stack<char> left = new Stack<char>();
    private Stack<char> right = new Stack<char>();

    public void AddText(string text)
    {
        foreach (var charItem in text)
        {
            left.Push(charItem);
        }
    }

    public int DeleteText(int k)
    {
        var count = 0;
        for (int i = 0; i < k; i++)
        {
            if (left.Count > 0)
            {
                left.Pop();
                count++;
            }
        }
        return count;
    }

    public string CursorLeft(int k)
    {
        for (int i = 0; i < k; i++)
        {
            if (left.Count > 0)
            {
                right.Push(left.Pop());
            }
        }
        return GetLeftString();
    }

    public string CursorRight(int k)
    {
        for (int i = 0; i < k; i++)
        {
            if (right.Count > 0)
            {
                left.Push(right.Pop());
            }
        }
        return GetLeftString();
    }
    private string GetLeftString()
    {
        var chars = new Stack<char>();
        var count = 10;
        while (count > 0 && left.Count > 0)
        {
            chars.Push(left.Pop());
            count--;
        }
        var s = new string(chars.ToArray());
        while(chars.Count > 0)
        {
            left.Push(chars.Pop());
        }
        return s;
    }
}

/**
 * Your TextEditor object will be instantiated and called as such:
 * TextEditor obj = new TextEditor();
 * obj.AddText(text);
 * int param_2 = obj.DeleteText(k);
 * string param_3 = obj.CursorLeft(k);
 * string param_4 = obj.CursorRight(k);
 */