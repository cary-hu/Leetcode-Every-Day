using System;
/// <summary>
/// 20220915
/// https://leetcode.cn/problems/word-search/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public bool Exist(char[][] board, string word)
    {
        for (int i = 0; i < board.Length; ++i)
        {
            for (int j = 0; j < board[i].Length; ++j)
            {
                if (board[i][j] == word[0])
                {
                    if (DFS(board, word, i, j, 0)) return true;
                }
            }
        }
        return false;
    }
    private bool DFS(char[][] board, string word, int i, int j, int k)
    {
        if (k == word.Length)
        {
            return true;
        }
        if (i < 0 || j < 0 || i >= board.Length || j >= board[i].Length)
        {
            return false;
        }

        if (word[k] != board[i][j])
        {
            return false;
        }
        char t = board[i][j];
        board[i][j] = '0';
        bool res = DFS(board, word, i + 1, j, k + 1) ||
        DFS(board, word, i - 1, j, k + 1) ||
        DFS(board, word, i, j + 1, k + 1) ||
        DFS(board, word, i, j - 1, k + 1);
        board[i][j] = t;
        return res;
    }
}