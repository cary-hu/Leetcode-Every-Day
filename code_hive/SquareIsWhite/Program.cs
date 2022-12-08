/// <summary>
/// 20221208
/// https://leetcode.cn/problems/determine-color-of-a-chessboard-square/
/// </summary>
public class Solution
{
    public bool SquareIsWhite(string coordinates)
    {
        var num1 = coordinates[0] - 'a';
        var num2 = coordinates[1] - '0';
        return (num1 + num2) % 2 == 0;
    }
}