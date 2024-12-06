/// <summary>
/// 20241206
/// https://leetcode.cn/problems/available-captures-for-rook/
/// </summary>
public class Solution
{
    public int NumRookCaptures(char[][] board)
    {
        int x = 0, y = 0;
        int n = board.Length;
        int m = board[0].Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (board[i][j] == 'R')
                {
                    x = i;
                    y = j;
                }
            }
        }
        int cnt = 0;
        int[] dx = [0, 1, 0, -1];
        int[] dy = [1, 0, -1, 0];
        for (int i = 0; i < 4; i++)
        {
            for (int step = 0; ; step++)
            {
                int tx = x + step * dx[i];
                int ty = y + step * dy[i];
                if (tx < 0 || tx >= 8 || ty < 0 || ty >= 8 || board[tx][ty] == 'B')
                {
                    break;
                }
                if (board[tx][ty] == 'p')
                {
                    cnt++;
                    break;
                }
            }
        }
        return cnt;
    }
}