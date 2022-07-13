/// <summary>
/// 20220713
/// https://leetcode.cn/problems/asteroid-collision/
/// </summary>
public class Solution
{
    public int[] AsteroidCollision(int[] asteroids)
    {
        Stack<int> stack = new Stack<int>();
        foreach (int aster in asteroids)
        {
            bool alive = true;
            while (alive && aster < 0 && stack.Count > 0 && stack.Peek() > 0)
            {
                alive = stack.Peek() < -aster; // aster 是否存在
                if (stack.Peek() <= -aster)
                {  // 栈顶行星爆炸
                    stack.Pop();
                }
            }
            if (alive)
            {
                stack.Push(aster);
            }
        }
        
        int count = stack.Count;
        int[] ans = new int[count];
        for (int i = count - 1; i >= 0; i--)
        {
            ans[i] = stack.Pop();
        }
        return ans;

    }
}