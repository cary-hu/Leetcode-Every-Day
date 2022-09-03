using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hammingDistance​​
{
    internal class GetMaximumGold​​
    {
        private int _res = 0;
        public int GetMaximumGold(int[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] != 0)
                    {
                        DFS(i, j, 0, grid);
                    }
                }
            }
            return _res;
        }
        private void DFS(int x, int y, int gold, int[][] grid)
        {
            var d = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
            gold += grid[x][y];
            _res = Math.Max(_res, gold);
            int revert = grid[x][y];
            grid[x][y] = 0;
            for (int i = 0; i < 4; i++)
            {
                int dx = x + d[i][0];
                int dy = y + d[i][1];
                if (dx >= 0 && dx < grid.Length && dy >= 0 && dy < grid[0].Length && grid[dx][dy] != 0)
                {
                    DFS(dx, dy, gold, grid);
                }
            }
            grid[x][y] = revert;
        }
    }
}
