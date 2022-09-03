/// <summary>
/// 20220902
/// https://leetcode.cn/problems/design-a-text-editor/
/// </summary>
public class TextEditor
{

    private List<char> left = new List<char>();
    private List<char> right = new List<char>();
    private int cursorIndex = -1;

    public void AddText(string text)
    {
        foreach (var charItem in text)
        {
            left.Add(charItem);
            cursorIndex++;
        }
    }

    public int DeleteText(int k)
    {
        var count = 0;
        for (int i = 0; i < k; i++)
        {
            if (cursorIndex != -1)
            {
                left.RemoveAt(left.Count - 1);
                cursorIndex--;
                count++;
            }
        }
        return count;
    }

    public string CursorLeft(int k)
    {
        for (int i = 0; i < k; i++)
        {
            if (cursorIndex != -1)
            {
                var leftTrial = left[left.Count - 1];
                right.Insert(0, leftTrial);
                left.RemoveAt(left.Count - 1);
                cursorIndex--;
            }
        }
        var len = Math.Min(10, cursorIndex + 1);
        var index = cursorIndex;
        var s = "";
        for (int i = 0; i < len; i++)
        {
            s = left[index--] + s;
        }
        return s;
    }

    public string CursorRight(int k)
    {
        for (int i = 0; i < k; i++)
        {
            if (right.Count > 0)
            {
                var rightHead = right[0];
                left.Add(rightHead);
                right.RemoveAt(0);
                cursorIndex++;
            }
        }
        var len = Math.Min(10, cursorIndex + 1);
        var index = cursorIndex;
        var s = "";
        for (int i = 0; i < len; i++)
        {
            s = left[index--] + s;
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