/// <summary>
/// 20220912
/// https://leetcode.cn/problems/surrounded-regions/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    private int n;
    private int m;
    public void Solve(char[][] board)
    {
        n = board.Length;
        if(n == 0)
        {
            return;
        }
        m = board[0].Length;
        for (int i = 0; i < n; i++)
        {
            DFS(board, i, 0);
            DFS(board, i, m - 1);
        }
        for (int i = 1; i < m - 1; i++)
        {
            DFS(board, 0, i);
            DFS(board, n - 1, i);
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (board[i][j] == 'A')
                {
                    board[i][j] = 'O';
                } else if (board[i][j] == 'O')
                {
                    board[i][j] = 'X';
                }
            }
        }
    }
    public void DFS(char[][] board, int x, int y)
    {
        if (x < 0|| x>=n||y < 0 || y >= m || board[x][y] !='O')
        {
            return;
        }
        board[x][y] = 'A';
        DFS(board, x + 1, y);
        DFS(board, x - 1, y);
        DFS(board, x, y + 1);
        DFS(board, x, y - 1);

    }
}