/// <summary>
/// 20250919
/// https://leetcode.cn/problems/design-spreadsheet/
/// </summary>
public class Spreadsheet
{
    private Dictionary<string, int> cells = new Dictionary<string, int>();

    public Spreadsheet(int rows)
    {

    }
    public void SetCell(string cell, int value)
    {
        cells[cell] = value;
    }

    public void ResetCell(string cell)
    {
        cells.Remove(cell);
    }
    private int GetCell(string cell)
    {
        if (int.TryParse(cell, out int numberValue))
        {
            return numberValue;
        }
        if (cells.TryGetValue(cell, out int value))
        {
            return value;
        }
        return 0;
    }

    public int GetValue(string formula)
    {
        var index = formula.IndexOf('+');
        return GetCell(formula[1..index]) + GetCell(formula[(index + 1)..]);
    }
}

/**
 * Your Spreadsheet object will be instantiated and called as such:
 * Spreadsheet obj = new Spreadsheet(rows);
 * obj.SetCell(cell,value);
 * obj.ResetCell(cell);
 * int param_3 = obj.GetValue(formula);
 */