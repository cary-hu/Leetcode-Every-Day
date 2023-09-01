/// <summary>
/// 20230825
/// https://leetcode.cn/problems/robot-collisions/
/// </summary>
public class Solution
{
    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
    {

        int n = positions.Length;
        var id = new int[n];
        for (int i = 0; i < n; ++i) id[i] = i;
        Array.Sort(id, (a,b) => positions[a] - positions[b]);
        var st = new Stack<int>();
        foreach (int i in id)
        {
            if (directions[i] == 'R')
            { 
                st.Push(i);
                continue;
            }
            while (st.Count != 0)
            {
                int top = st.Peek();
                if (healths[top] > healths[i])
                {
                    healths[top]--;
                    healths[i] = 0;
                    break;
                }
                var topRobot = st.Pop();
                if (healths[top] == healths[i])
                {
                    healths[topRobot] = 0;
                    healths[i] = 0;
                    break;
                }
                healths[topRobot] = 0;
                healths[i]--;
            }
        }

        var ans = new List<int>();
        foreach (int h in healths) if (h > 0) ans.Add(h);
        return ans;
    }
}