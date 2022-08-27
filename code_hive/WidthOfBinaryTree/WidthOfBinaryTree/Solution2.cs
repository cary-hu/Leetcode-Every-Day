using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidthOfBinaryTree
{
    public class Solution2
    {
        public int WidthOfBinaryTree(TreeNode root)
        {
            int res = 1;
            IList<Tuple<TreeNode, int>> arr = new List<Tuple<TreeNode, int>>();
            arr.Add(new Tuple<TreeNode, int>(root, 1));
            while (arr.Count > 0)
            {
                IList<Tuple<TreeNode, int>> tmp = new List<Tuple<TreeNode, int>>();
                foreach (Tuple<TreeNode, int> pair in arr)
                {
                    TreeNode node = pair.Item1;
                    int index = pair.Item2;
                    if (node.left != null)
                    {
                        tmp.Add(new Tuple<TreeNode, int>(node.left, index * 2));
                    }
                    if (node.right != null)
                    {
                        tmp.Add(new Tuple<TreeNode, int>(node.right, index * 2 + 1));
                    }
                }
                res = Math.Max(res, arr[arr.Count - 1].Item2 - arr[0].Item2 + 1);
                arr = tmp;
            }
            return res;
        }
    }
}
