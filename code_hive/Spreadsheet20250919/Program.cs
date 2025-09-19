/// <summary>
/// 20250919
/// https://leetcode.cn/problems/design-spreadsheet/
/// </summary>
public class Spreadsheet
{
    private int[] cells;

    public Spreadsheet(int rows)
    {
        cells = new int[rows * 26];
    }
    private int ParseRow(string cell)
    {
        return int.Parse(cell[1..]) - 1;
    }
    private int ParseCol(string cell)
    {
        return cell[0] - 'A';
    }
    public void SetCell(string cell, int value)
    {
        int row = ParseRow(cell);
        int col = ParseCol(cell);
        cells[row * 26 + col] = value;
    }

    public void ResetCell(string cell)
    {
        SetCell(cell, 0);
    }
    private int GetCell(string cell)
    {
        if (int.TryParse(cell, out int numberValue))
        {
            return numberValue;
        }
        int row = ParseRow(cell);
        int col = ParseCol(cell);
        return cells[row * 26 + col];
    }

    public int GetValue(string formula)
    {
        return formula.Split('=')[1].Split('+')
            .Select(cell => GetCell(cell))
            .Sum();
    }
}

/**
 * Your Spreadsheet object will be instantiated and called as such:
 * Spreadsheet obj = new Spreadsheet(rows);
 * obj.SetCell(cell,value);
 * obj.ResetCell(cell);
 * int param_3 = obj.GetValue(formula);
 */