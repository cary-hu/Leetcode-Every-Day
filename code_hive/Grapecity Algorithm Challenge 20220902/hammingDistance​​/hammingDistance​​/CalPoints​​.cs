namespace hammingDistance​​
{
    internal class CalPoints​​
    {
        public int CalPoints(string[] ops)
        {
            var stack = new Stack<int>();
            foreach (var op in ops)
            {
                if (op == "C")
                {
                    stack.Pop();
                }
                else if (op == "D")
                {
                    var head = stack.Peek();
                    stack.Push(head * 2);
                }
                else if (op == "+")
                {
                    var first = stack.Pop();
                    var second = stack.Pop();
                    var third = first + second;
                    stack.Push(second);
                    stack.Push(first);
                    stack.Push(third);​​

                }
                else
                {
                    stack.Push(Convert.ToInt32(op));
                }​​
            }​​
            return stack.Sum();
        }​​
    }
}
