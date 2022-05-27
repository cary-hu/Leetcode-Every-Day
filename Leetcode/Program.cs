using System.Text.RegularExpressions;


var a = new Solution();

a.CountValidWords("he bought 2 pencils, 3 erasers, and 1  pencil-sharpener.");
public class Solution
{
    public int CountValidWords(string sentence)
    {
        var words = sentence.Split(' ');
        var count = 0;
        foreach (var word in words)
        {
            if (string.IsNullOrEmpty(word))
            {
                continue;
            }
            if (IsValidWord(word))
            {
                count++;
            }
        }
        return count;
    }
    private bool IsValidWord(string word)
    {
        int n = word.Length;
        bool hasHyphens = false;
        for (int i = 0; i < n; i++)
        {
            if (char.IsDigit(word[i]))
            {
                return false;
            }
            else if (word[i] == '-')
            {
                if (hasHyphens == true || i == 0 || i == n - 1 || !char.IsLetter(word[i - 1]) || !char.IsLetter(word[i + 1]))
                {
                    return false;
                }
                hasHyphens = true;
            }
            else if (word[i] == '!' || word[i] == '.' || word[i] == ',')
            {
                if (i != n - 1)
                {
                    return false;
                }
            }
        }
        return true;
    }
    public int FindClosest(string[] words, string word1, string word2)
    {
        var n = words.Length;
        var min = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            if (words[i] != word1)
            {
                continue;
            }
            for (int j = 0; j < n; j++)
            {
                if (words[j] != word2)
                {
                    continue;
                }
                min = Math.Min(min, Math.Abs(j - i));
            }
        }
        return min;
    }
    public Node Connect(Node root)
    {
        if (root == null)
            return null;
        if (root.left != null)
            root.left.next = root.right;
        if (root.right != null)
            root.right.next = root.next?.left;
        Connect(root.left);
        Connect(root.right);
        return root;
    }
    public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
    {
        var root = new TreeNode(0);
        if (root1 == null && root2 == null)
        {
            return null;
        }
        if (root1 == null)
        {
            return root2;
        }
        if (root2 == null)
        {
            return root1;
        }
        root.val = root1.val + root2.val;
        root.left = MergeTrees(root1.left, root2.left);
        root.right = MergeTrees(root1.right, root2.right);


        return root;
    }
    public int MaxAreaOfIsland(int[][] grid)
    {
        var res = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    var tempRes = GetArea(grid, i, j);
                    res = Math.Max(res, tempRes);
                }
            }
        }

        return res;
    }

    private int GetArea(int[][] grid, int i, int j)
    {
        if (i == grid.Length || i < 0)
            return 0;
        else if (j == grid[0].Length || j < 0)
            return 0; ;
        if (grid[i][j] == 1)
        {
            grid[i][j] = 0;
            return 1 + GetArea(grid, i + 1, j) + GetArea(grid, i - 1, j) + GetArea(grid, i, j + 1) + GetArea(grid, i, j - 1);
        }
        return 0;
    }
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
    {
        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((sr, sc));
        var originColor = image[sr][sc];
        int xLength = image.Length;
        int yLength = image[0].Length;
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            image[current.x][current.y] = -1;
            if (0 <= current.x - 1 && image[current.x - 1][current.y] == originColor)
            {
                queue.Enqueue((current.x - 1, current.y));

            }
            if (xLength > current.x + 1 && image[current.x + 1][current.y] == originColor)
            {
                queue.Enqueue((current.x + 1, current.y));

            }
            if (0 <= current.y - 1 && image[current.x][current.y - 1] == originColor)
            {
                queue.Enqueue((current.x, current.y - 1));

            }
            if (yLength > current.y + 1 && image[current.x][current.y + 1] == originColor)
            {
                queue.Enqueue((current.x, current.y + 1));
            }
        }
        for (int i = 0; i < xLength; i++)
        {
            for (int j = 0; j < yLength; j++)
            {
                if (image[i][j] == -1)
                {
                    image[i][j] = newColor;
                }
            }
        }
        return image;
    }
    public IList<int> FallingSquares(int[][] positions)
    {
        int n = positions.Length;
        IList<int> heights = new List<int>();
        for (int i = 0; i < n; i++)
        {
            int left1 = positions[i][0];
            int right1 = positions[i][0] + positions[i][1] - 1;
            heights.Add(positions[i][1]);
            for (int j = 0; j < i; j++)
            {
                int left2 = positions[j][0];
                int right2 = positions[j][0] + positions[j][1] - 1;
                if (right1 >= left2 && right2 >= left1)
                {
                    heights[i] = Math.Max(heights[i], heights[j] + positions[i][1]);
                }
            }
        }
        for (int i = 1; i < n; i++)
        {
            heights[i] = Math.Max(heights[i], heights[i - 1]);
        }
        return heights;
    }
    public int FindSubstringInWraproundString(string p)
    {
        var dic = new Dictionary<char, int>();
        var max = 0;
        for (var i = 0; i < p.Length; i++)
        {
            if (i > 0 && (p[i] - p[i - 1] == 1 || p[i] - p[i - 1] == -25))
            {
                max++;
            }
            else
            {
                max = 1;
            }
            if (dic.ContainsKey(p[i]))
            {
                dic[p[i]] = Math.Max(dic[p[i]], max);
            }
            else
            {
                dic.Add(p[i], max);
            }
        }
        return dic.Values.Sum();

    }
    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            return false;

        var s1Hash = new int[26];
        var s2Hash = new int[26];

        for (int i = 0; i < s1.Length; i++)
        {
            s1Hash[s1[i] - 'a']++;
            s2Hash[s2[i] - 'a']++;
        }

        for (int i = s1.Length; i < s2.Length; i++)
        {
            if (s1Hash.SequenceEqual(s2Hash))
                return true;

            s2Hash[s2[i] - 'a']++;
            s2Hash[s2[i - s1.Length] - 'a']--;
        }

        return s1Hash.SequenceEqual(s2Hash);
    }
    public int LengthOfLongestSubstring(string s)
    {
        var start = 0;
        var end = 0;
        var max = 0;
        var set = new HashSet<char>();
        while (end < s.Length)
        {
            if (!set.Contains(s[end]))
            {
                set.Add(s[end]);
                end++;
                max = Math.Max(max, end - start);
            }
            else
            {
                set.Remove(s[start]);
                start++;
            }
        }
        return max;
    }
    public ListNode MiddleNode(ListNode head)
    {
        if (head == null)
            return null;
        ListNode slow = head;
        ListNode fast = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        return slow;
    }
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var dummy = new ListNode(-1);
        dummy.next = head;
        var slow = dummy;
        var fast = dummy;
        while (n-- > 0)
        {
            fast = fast.next;
        }
        while (fast.next != null)
        {
            fast = fast.next;
            slow = slow.next;
        }
        slow.next = slow.next.next;
        return dummy.next;
    }
    public bool IsUnivalTree(TreeNode root)
    {
        if (root == null)
        {
            return true;
        }
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        while (q.Count > 0)
        {
            var node = q.Dequeue();
            if (node.left != null)
            {
                if (node.left.val != node.val)
                    return false;
                q.Enqueue(node.left);
            }
            if (node.right != null)
            {
                if (node.right.val != node.val)
                    return false;
                q.Enqueue(node.right);
            }
        }
        return true;
    }
    public void ReverseString(char[] s)
    {
        var i = 0;
        var j = s.Length - 1;
        while (i < j)
        {
            var temp = s[i];
            s[i] = s[j];
            s[j] = temp;
            i++;
            j--;
        }
    }
    public string ReverseWords(string s)
    {
        var words = s.Split(' ');
        var result = new string[words.Length];
        for (int i = 0; i < words.Length; i++)
        {
            var word = words[i];
            var tempWord = "";
            for (var j = word.Length - 1; j >= 0; j--)
            {
                tempWord += word[j];
            }
            result[i] = tempWord;
        }
        return string.Join(" ", result);

    }
    int[][] dirs = { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };

    public int CutOffTree(IList<IList<int>> forest)
    {
        List<Tuple<int, int>> trees = new List<Tuple<int, int>>();
        int row = forest.Count;
        int col = forest[0].Count;
        for (int i = 0; i < row; ++i)
        {
            for (int j = 0; j < col; ++j)
            {
                if (forest[i][j] > 1)
                {
                    trees.Add(new Tuple<int, int>(i, j));
                }
            }
        }
        trees.Sort((a, b) => forest[a.Item1][a.Item2] - forest[b.Item1][b.Item2]);

        int cx = 0;
        int cy = 0;
        int ans = 0;
        for (int i = 0; i < trees.Count; ++i)
        {
            int steps = BFS(forest, cx, cy, trees[i].Item1, trees[i].Item2);
            if (steps == -1)
            {
                return -1;
            }
            ans += steps;
            cx = trees[i].Item1;
            cy = trees[i].Item2;
        }
        return ans;
    }

    public int BFS(IList<IList<int>> forest, int sx, int sy, int tx, int ty)
    {
        if (sx == tx && sy == ty)
        {
            return 0;
        }

        int row = forest.Count;
        int col = forest[0].Count;
        int step = 0;
        Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
        bool[,] visited = new bool[row, col];
        queue.Enqueue(new Tuple<int, int>(sx, sy));
        visited[sx, sy] = true;
        while (queue.Count > 0)
        {
            step++;
            int sz = queue.Count;
            for (int i = 0; i < sz; ++i)
            {
                Tuple<int, int> cell = queue.Dequeue();
                int cx = cell.Item1, cy = cell.Item2;
                for (int j = 0; j < 4; ++j)
                {
                    int nx = cx + dirs[j][0];
                    int ny = cy + dirs[j][1];
                    if (nx >= 0 && nx < row && ny >= 0 && ny < col)
                    {
                        if (!visited[nx, ny] && forest[nx][ny] > 0)
                        {
                            if (nx == tx && ny == ty)
                            {
                                return step;
                            }
                            queue.Enqueue(new Tuple<int, int>(nx, ny));
                            visited[nx, ny] = true;
                        }
                    }
                }
            }
        }
        return -1;
    }
    public int[] TwoSum(int[] numbers, int target)
    {
        int[] result = new int[2];
        int i = 0;
        int j = numbers.Length - 1;
        while (i < j)
        {
            if (numbers[i] + numbers[j] == target)
            {
                result[0] = i + 1;
                result[1] = j + 1;
                break;
            }
            else if (numbers[i] + numbers[j] < target)
            {
                i++;
            }
            else
            {
                j--;
            }
        }
        return result;
    }
    public void MoveZeroes(int[] nums)
    {
        int i = 0;
        int j = 0;
        while (i < nums.Length && j < nums.Length)
        {
            if (nums[i] == 0)
            {
                i++;
            }
            else
            {
                nums[j] = nums[i];
                i++;
                j++;
            }
        }
        while (j < nums.Length)
        {
            nums[j] = 0;
            j++;
        }

    }
    Dictionary<int, bool> memo = new Dictionary<int, bool>();

    public bool CanIWin(int maxChoosableInteger, int desiredTotal)
    {
        if ((1 + maxChoosableInteger) * (maxChoosableInteger) / 2 < desiredTotal)
        {
            return false;
        }
        return DFS(maxChoosableInteger, 0, desiredTotal, 0);
    }

    public bool DFS(int maxChoosableInteger, int usedNumbers, int desiredTotal, int currentTotal)
    {
        if (!memo.ContainsKey(usedNumbers))
        {
            bool res = false;
            for (int i = 0; i < maxChoosableInteger; i++)
            {
                if (((usedNumbers >> i) & 1) == 0)
                {
                    if (i + 1 + currentTotal >= desiredTotal)
                    {
                        res = true;
                        break;
                    }
                    if (!DFS(maxChoosableInteger, usedNumbers | (1 << i), desiredTotal, currentTotal + i + 1))
                    {
                        res = true;
                        break;
                    }
                }
            }
            memo.Add(usedNumbers, res);
        }
        return memo[usedNumbers];
    }
    public int[] SortedSquares(int[] nums)
    {
        var i = 0;
        var j = nums.Length - 1;
        var result = new int[nums.Length];
        var pos = nums.Length - 1;
        while (i <= j)
        {
            if (nums[i] * nums[i] > nums[j] * nums[j])
            {
                result[pos] = nums[i] * nums[i];
                ++i;
            }
            else
            {
                result[pos] = nums[j] * nums[j];
                --j;
            }
            --pos;
        }
        return result;
    }
    public void Rotate(int[] nums, int k)
    {
        var n = nums.Length;
        k = k % n;
        var temp = new int[n];
        for (int i = 0; i < n; i++)
        {
            temp[(i + k) % n] = nums[i];
        }
        for (int i = 0; i < n; i++)
        {
            nums[i] = temp[i];
        }


    }
    public int RepeatedNTimes(int[] nums)
    {
        var count = nums.Length / 2;
        var dict = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (dict.ContainsKey(num))
            {
                dict[num]++;
            }
            else
            {
                dict.Add(num, 1);
            }
        }

        foreach (var item in dict)
        {
            if (item.Value == count)
            {
                return item.Key;
            }
        }
        return -1;
    }
    public int SearchInsert(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return nums.Length;
    }
    private bool IsBadVersion(int mid)
    {
        return false;
    }
    public int FirstBadVersion(int n)
    {
        var left = 0;
        var right = n;
        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (IsBadVersion(mid))
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }
        return left;
    }
    public int BinarySearch(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return -1;
    }
    public int[] FindRightInterval(int[][] intervals)
    {
        var list = new List<int>();
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < intervals.Length; i++)
        {
            dict.Add(intervals[i][0], i);
        }
        var sorted = intervals.OrderBy(x => x[0]).ToArray();
        for (int i = 0; i < intervals.Length; i++)
        {
            var interval = intervals[i];
            var index = BinarySearch(sorted, interval[1]);
            if (index != -1)
            {
                list.Add(dict[sorted[index][0]]);
            }
            else
            {

                list.Add(index);
            }
        }
        return list.ToArray();
    }
    private int BinarySearch(int[][] intervals, int interval)
    {
        int left = 0;
        int right = intervals.Length - 1;
        var res = -1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (intervals[mid][0] >= interval)
            {
                res = mid;
            }
            else if (intervals[mid][0] < interval)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return res;
    }
    public int[] PlusOne(int[] digits)
    {
        int t = 1;
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            digits[i] += t;
            t = digits[i] / 10;
            digits[i] %= 10;
        }
        var list = digits.ToList();
        if (t == 1)
        {
            list.Add(0);
            for (int i = list.Count - 2; i >= 0; i--)
                list[i + 1] = list[i];
            list[0] = 1;
        }
        return list.ToArray();
    }
    public int MinMoves2(int[] nums)
    {
        var res = 0;
        var orderedNums = nums.OrderBy(x => x).ToList();
        var middle = orderedNums[nums.Length / 2];
        for (int i = 0; i < nums.Length; i++)
        {
            res += Math.Abs(nums[i] - middle);
        }
        return res;
    }
    public bool OneEditAway(string first, string second)
    {
        var firstLength = first.Length;
        var secondLength = second.Length;
        if (firstLength == secondLength)
        {
            var diffCount = 0;
            for (int i = 0; i < firstLength; i++)
            {
                if (first[i] != second[i])
                {
                    diffCount++;
                }
            }
            return diffCount <= 1;
        }
        else if (firstLength - secondLength == 1 || secondLength - firstLength == 1)
        {
            var shortStr = firstLength < secondLength ? first : second;
            var longStr = firstLength < secondLength ? second : first;
            int length1 = shortStr.Length, length2 = longStr.Length;
            int index1 = 0, index2 = 0;
            while (index1 < length1 && index2 < length2)
            {
                if (shortStr[index1] == longStr[index2])
                {
                    index1++;
                }
                index2++;
                if (index2 - index1 > 1)
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public int MinMutation(string start, string end, string[] bank)
    {
        var isValid = false;
        for (int i = 0; i < bank.Length; i++)
        {
            if (end == bank[i])
            {
                isValid = true;
                break;
            }
        }
        if (!isValid)
        {
            return -1;
        }

        var hashSet = new Dictionary<(string origin, string target), int>();
        for (int i = 0; i < bank.Length; i++)
        {
            var startDiffCount = getStringDiffCount(start, bank[i]);
            if (startDiffCount <= 1)
            {
                insertToDictionary(start, bank[i], startDiffCount, hashSet);
            }
            var endDiffCount = getStringDiffCount(bank[i], end);
            if (endDiffCount <= 1)
            {
                insertToDictionary(bank[i], end, endDiffCount, hashSet);
            }

            for (int j = 0; j < bank.Length; j++)
            {
                var diffCount = getStringDiffCount(bank[i], bank[j]);
                if (diffCount > 1)
                {
                    continue;
                }
                insertToDictionary(bank[i], bank[j], diffCount, hashSet);
            }
        }
        var ans = 0;
        var queue = new Queue<string>();
        queue.Enqueue(start);
        while (queue.Count > 0)
        {
            var waitingForEnqueue = new List<string>();
            var solved = false;
            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                if (current == end)
                {
                    solved = true;
                    break;
                }
                var allPath = hashSet.Keys.Where(x => x.origin == current).Select(x => x.target).ToList();
                waitingForEnqueue.AddRange(allPath);
            }
            if (solved)
            {
                break;
            }
            ans++;
            if (ans > hashSet.Count)
            {
                ans = -1;
                break;
            }
            for (int i = 0; i < waitingForEnqueue.Count(); i++)
            {
                queue.Enqueue(waitingForEnqueue[i]);
            }
        }
        return ans == int.MaxValue ? -1 : ans;
    }
    private void insertToDictionary(string origin, string target, int count, Dictionary<(string origin, string target), int> hashSet)
    {
        if (hashSet.ContainsKey((origin, target)))
        {
            hashSet.TryGetValue((origin, target), out int conut);
            if (conut > count)
            {

                hashSet[(origin, target)] = count;
            }
        }
        else
        {
            hashSet.Add((origin, target), count);
        }
    }
    private int getStringDiffCount(string origin, string target)
    {
        var count = 0;
        for (int i = 0; i < origin.Length; i++)
        {
            if (origin[i] != target[i])
            {
                count++;
            }
        }
        return count;
    }
    private uint parseDNAStringToUint(string s)
    {
        uint n = 0;
        for (int i = 0; i < 8; i++)
        {
            n <<= 4;
            char c = s[i];
            switch (c)
            {
                case 'A':
                    n |= 1;
                    break;
                case 'C':
                    n |= 2;
                    break;
                case 'G':
                    n |= 4;
                    break;
                case 'T':
                    n |= 8;
                    break;
            }
        }
        return n;
    }
    private bool canTransfer(uint from, uint to)
    {
        uint diff = from ^ to;
        return (diff & 0xf) == diff
        || (diff & 0xf0) == diff
        || (diff & 0xf00) == diff
        || (diff & 0xf000) == diff
        || (diff & 0xf0000) == diff
        || (diff & 0xf00000) == diff
        || (diff & 0xf000000) == diff
        || (diff & 0xf0000000) == diff;
    }

    public int ThirdMax(int[] nums)
    {
        var distinctNums = nums.Distinct();
        var length = distinctNums.Count();
        var index = length > 2 ? 2 : length - 1;
        if (length > 2)
        {
            return distinctNums.OrderByDescending(x => x).ElementAt(index);
        }
        else
        {
            return distinctNums.OrderBy(x => x).ElementAt(index);
        }
    }
    public int NearestValidPoint(int x, int y, int[][] points)
    {
        var min = int.MaxValue;
        int ans = -1;
        for (int i = 0; i < points.Length; i++)
        {
            int[] point = points[i];
            int a = point[0], b = point[1];
            if (a == x || b == y)
            {
                int dist = Math.Abs(a - x) + Math.Abs(b - y);
                if (dist < min)
                {
                    ans = i;
                    min = dist;
                }
            }
        }
        return ans;
    }
    public QuadTreeNode Construct(int[][] grid)
    {
        return GenerateNode(grid, 0, 0, grid.Length, grid.Length);
    }
    private QuadTreeNode GenerateNode(int[][] grid, int x1, int y1, int x2, int y2)
    {
        var isSameArea = true;
        for (int i = x1; i < x2; i++)
        {
            for (int j = y1; j < y2; j++)
            {
                if (grid[i][j] != grid[x1][y1])
                {
                    isSameArea = false;
                    break;
                }
            }
        }
        if (isSameArea)
        {
            return new QuadTreeNode(grid[x1][y1] == 1, true);
        }
        else
        {
            return new QuadTreeNode(
                true,
                false,
                GenerateNode(grid, x1, y1, (x1 + x2) / 2, (y1 + y2) / 2),
                GenerateNode(grid, (x1 + x2) / 2, y1, x2, (y1 + y2) / 2),
                GenerateNode(grid, x1, (y1 + y2) / 2, (x1 + x2) / 2, y2),
                GenerateNode(grid, (x1 + x2) / 2, (y1 + y2) / 2, x2, y2)
                );
        }
    }
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        int size = flowerbed.Length;
        int i = 0;
        while (i < flowerbed.Length)
        {
            if (flowerbed[i] == 0)
            {
                if (i == size - 1)
                {
                    n--;
                    break;
                }
                if (i + 1 == size)
                {
                    break;
                }
                if (flowerbed[i + 1] == 0)
                {
                    n--;
                    i += 2;
                }
                else if (flowerbed[i + 1] == 1)
                {
                    i += 3;
                }
            }
            else if (flowerbed[i] == 1)
            {
                i += 2;
            }
        }
        return n <= 0;
    }
    public int MaxRotateFunction(int[] nums)
    {
        int f = 0, n = nums.Length, numSum = nums.Sum();
        for (int i = 0; i < n; i++)
        {
            f += i * nums[i];
        }
        int res = f;
        for (int j = 0; j < n - 1; j++)
        {
            f = f - numSum + n * nums[j];
            res = Math.Max(res, f);
        }
        return res;
    }
    public int MySqrt(int x)
    {
        int l = 0, r = x;
        while (l < r)
        {
            int mid = l + r + 1 >> 1;
            if (mid <= x / mid) l = mid;
            else r = mid - 1;
        }
        return r;
    }
    public int FindMin(int[] nums)
    {
        int left = 0, right = nums.Length - 1, mid = (left + right) / 2;
        while (left < right)
        {
            mid = left + (right + left) / 2;

            if (nums[left] < nums[right])
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }
        return nums[left];
    }
    public string ToGoatLatin(string sentence)
    {
        var vowelList = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
        var words = sentence.Split(' ');
        var res = new List<string>();
        var index = 1;
        foreach (var word in words)
        {
            var tempWord = word;
            if (vowelList.Contains(word.ToLowerInvariant()[0]))
            {
                tempWord = word + "ma";
            }
            else
            {

                tempWord = word.Remove(0, 1) + word[0] + "ma";
            }
            tempWord += new string('a', index++);
            res.Add(tempWord);
        }
        return string.Join(' ', res);
    }
    private int gcd(int x, int y)
    {
        return x == 0 ? y : gcd(y % x, x);
    }
    public bool HasGroupsSizeX(int[] deck)
    {
        var map = new Dictionary<int, int>();
        foreach (var c in deck)
        {
            if (!map.ContainsKey(c))
            {
                map.Add(c, 1);
            }
            else
            {
                map[c]++;
            }
        }

        int g = -1;
        foreach (var item in map)
        {
            if (item.Value > 0)
            {
                if (g == -1)
                {
                    g = item.Value;
                }
                else
                {
                    g = gcd(g, item.Value);
                }
            }
        }
        return g >= 2;
    }
    public bool CanBeIncreasing(int[] nums)
    {
        int cnt = 0;
        for (int i = 1; i < nums.Length && cnt <= 1; i++)
        {
            if (nums[i] > nums[i - 1]) continue;
            cnt++;
            if (i - 1 > 0 && nums[i] <= nums[i - 2])
            {
                nums[i] = nums[i - 1];
            }
            else
            {
                nums[i - 1] = nums[i];
            }
        }
        return cnt <= 1;
    }
    public IList<IList<int>> LevelOrder(Node root)
    {
        IList<IList<int>> res = new List<IList<int>>();
        if (root == null) { return res; }

        Queue<IList<Node>> q = new Queue<IList<Node>>();
        res.Add(new List<int>() { root.val });
        q.Enqueue(root.children);
        while (q.Count > 0)
        {
            var currentAllNode = new List<List<Node>>();
            while (q.Count > 0)
            {
                currentAllNode.Add(q.Dequeue().ToList());
            }
            var flatList = currentAllNode.SelectMany(x => x).ToList();
            var level = new List<int>();
            foreach (var item in flatList)
            {
                level.Add(item.val);
                q.Enqueue(item.children);
            }
            if (level.Count > 0)
            {
                res.Add(level);
            }
        }

        return res;
    }
    public int NumJewelsInStones(string jewels, string stones)
    {
        var jewelDir = new Dictionary<char, int>();
        for (int i = 0; i < jewels.Length; i++)
        {
            var currentJewel = jewels[i];
            jewelDir.Add(currentJewel, 0);
        }
        for (int i = 0; i < stones.Length; i++)
        {
            var currentStone = stones[i];
            if (jewelDir.ContainsKey(currentStone))
            {
                jewelDir[currentStone]++;
            }
        }
        return jewelDir.Sum(x => x.Value);
    }
    public bool StoneGame(int[] piles)
    {
        return true;
    }
    public bool IsLongPressedName(string name, string typed)
    {
        int i = 0, j = 0;
        while (j < typed.Length)
        {
            if (i < name.Length && name[i] == typed[j])
            {
                i++;
                j++;
            }
            else if (j > 0 && typed[j] == typed[j - 1])
            {
                j++;
            }
            else
            {
                return false;
            }
        }
        return i == name.Length;
    }
    public int TrailingZeroes(int n)
    {
        int ans = 0;
        while (n != 0)
        {
            n /= 5;
            ans += n;
        }
        return ans;
    }
    public bool IsPowerOfFour(int n)
    {
        return n > 0 && (n & (n - 1)) == 0 && n % 3 == 1;
    }
    public bool IsPowerOfThree(int n)
    {
        return n > 0 && 1162261467 % n == 0;
    }
    public bool IsPowerOfTwo(int n)
    {
        return n > 0 && (n & (n - 1)) == 0;
    }
    public int CountHighestScoreNodes(int[] parents)
    {
        var res = 0;
        var resDir = new Dictionary<int, int>();
        var dir = new Dictionary<int, List<int>>();

        for (int i = 1; i < parents.Length; i++)
        {
            if (dir.ContainsKey(parents[i]))
            {
                dir[parents[i]].Add(i);
            }
            else
            {
                dir.Add(parents[i], new List<int>() { i });
            }
        }

        for (int i = 0; i < parents.Length; i++)
        {


            var tempRes = 1;

            if (!dir.ContainsKey(i))
            {
                res = Math.Max(res, parents.Length - i);
                tempRes *= res;
            }
            else
            {

                foreach (var dirItem in dir)
                {
                    if (dirItem.Key == i)
                    {
                        continue;
                    }
                    foreach (var item in dirItem.Value)
                    {
                        var subNode = 1;
                        var queue = new Queue<int>();
                        queue.Enqueue(item);
                        while (queue.Count > 0)
                        {
                            var temp = queue.Dequeue();
                            if (dir.ContainsKey(temp) && temp != i)
                            {
                                foreach (var q in dir[temp])
                                {
                                    queue.Enqueue(q);
                                }
                                subNode += dir[temp].Count;
                            }
                            else
                            {
                                subNode++;
                            }
                        }
                        tempRes *= subNode;
                    }
                }
            }

            if (resDir.ContainsKey(tempRes))
            {
                resDir[tempRes]++;
            }
            else
            {
                resDir.Add(tempRes, 1);
            }
        }
        return res;
    }
    public int MaxIncreaseKeepingSkyline(int[][] grid)
    {
        int res = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                var xMax = int.MinValue;
                var yMax = int.MinValue;
                for (int k = 0; k < grid.Length; k++)
                {
                    xMax = Math.Max(grid[k][j], xMax);
                }
                for (int h = 0; h < grid[j].Length; h++)
                {
                    yMax = Math.Max(grid[i][h], yMax);
                }
                res += Math.Min(xMax, yMax) - grid[i][j];
            }
        }
        return res;
    }
    public int OrchestraLayout(int n, int xPos, int yPos)
    {
        int quan = (n + 1) / 2;
        long num = n;
        int layer = Math.Min(Math.Min(yPos, xPos), Math.Min(n - xPos - 1, n - yPos - 1)) + 1;
        long area = num * num;
        long zhong = (num - 2 * (layer - 1));
        zhong *= zhong;
        long index = (area - zhong) % 9 + 1;
        int right = n - layer;
        int left = layer - 1;
        if (xPos == left)
        {
            index += yPos - left;
        }
        else if (yPos == right)
        {
            index += right - left;
            index += xPos - left;
        }
        else if (xPos == right)
        {
            index += 2 * (right - left);
            index += right - yPos;
        }
        else
        {
            index += 3 * (right - left);
            index += right - xPos;
        }
        return (int)(index % 9 == 0 ? 9 : index % 9);
    }
    public long SubArrayRanges(int[] nums)
    {
        int n = nums.Length;
        long ret = 0;
        for (int i = 0; i < n; i++)
        {
            int minVal = int.MaxValue, maxVal = int.MinValue;
            for (int j = i; j < n; j++)
            {
                minVal = Math.Min(minVal, nums[j]);
                maxVal = Math.Max(maxVal, nums[j]);
                ret += maxVal - minVal;
            }
        }
        return ret;
    }
    public int MaximumDetonation(int[][] bombs)
    {
        var list = new List<int>();
        foreach (var item in bombs)
        {
            var x = item[0];
            var y = item[1];
            var r = item[2];

        }
        return 0;
    }
    public bool CanConstruct(string ransomNote, string magazine)
    {
        if (magazine.Length < ransomNote.Length)
        {
            return false;
        }
        var c = new Dictionary<char, int>();
        foreach (var item in magazine)
        {
            if (c.ContainsKey(item))
            {
                c[item]++;
            }
            else
            {
                c.Add(item, 1);
            }
        }
        foreach (var item in ransomNote)
        {
            if (!c.ContainsKey(item))
            {
                return false;
            }
            if (c[item] == 0)
            {
                return false;
            }
            c[item]--;
        }
        return true;
    }
    public string ComplexNumberMultiply(string num1, string num2)
    {
        var num1Parts = num1.Split('+');
        var num2Parts = num2.Split('+');
        var a = Convert.ToInt32(num1Parts[0]);
        var b = Convert.ToInt32(num1Parts[1].Replace("i", ""));
        var c = Convert.ToInt32(num2Parts[0]);
        var d = Convert.ToInt32(num2Parts[1].Replace("i", ""));
        var e = a * c - b * d;
        var f = a * d + b * c;
        return $"{e}+{f}i";
    }
    public int MinimumDifference(int[] nums, int k)
    {
        Array.Sort(nums);
        var res = int.MaxValue;
        for (int i = 0; i <= nums.Length - k; i++)
        {
            res = Math.Min(res, nums[i + k - 1] - nums[i]);
        }
        return res;
    }
    public bool BuddyStrings(string s, string goal)
    {
        if (s == goal)
        {
            if (s.Distinct().Count() < s.Length)
            {
                return true;
            }
            return false;
        }
        if (s.Length != goal.Length) return false;
        var count = 0;
        Dictionary<int, (string, string)> a = new Dictionary<int, (string, string)>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != goal[i])
            {
                a[count] = (s[i].ToString(), goal[i].ToString());
                count++;
            }
        }
        if (count != 2)
        {
            return false;
        }
        if (a == null)
        {
            return false;
        }
        return a[0].Item1 == a[1].Item2 && a[0].Item2 == a[1].Item1;
    }
    public string AddBinary(string a, string b)
    {
        if (a.Length < b.Length)
        {
            a = a + b;
            b = a.Substring(0, a.Length - b.Length);
            a = a.Substring(b.Length);
        }
        a = new string(a.ToCharArray().Reverse().ToArray());
        b = new string(b.ToCharArray().Reverse().ToArray());
        var res = "";
        var k = 0;
        var t = 0;
        while (k < b.Length)
        {
            t += a[k] - '0' + b[k] - '0';
            res += (t & 1).ToString();
            t /= 2;
            k++;
        }
        while (k < a.Length)
        {
            t += a[k] - '0';
            res += (t & 1).ToString();
            t /= 2;
            k++;
        }
        if (t == 1) res += '1';
        res = new string(res.ToCharArray().Reverse().ToArray());


        return res;
    }
    public void ZhiYingShu(int num)
    {
        var list = new List<int>();
        for (int i = 2; i <= num;)
        {
            if (num % i == 0)
            {
                list.Add(i);
                num = num / i;
            }
            else
            {
                if (i > num)
                {
                    break;
                }
                else
                {
                    i++;
                }
            }
        }
    }
    public int StatisticWordCount(string s, char target)
    {
        s = s.ToLower();
        var lowerTarget = target.ToString().ToLower()[0];
        var res = 0;
        foreach (var item in s)
        {
            if (item == lowerTarget)
            {
                res++;
            }
        }
        return res;
    }
    public int HammingWeight(uint n)
    {
        int ret = 0;
        for (int i = 0; i < 32; i++)
        {
            if ((n & (1 << i)) != 0)
            {
                ret++;
            }
        }
        return ret;
        int ans = 0;
        for (int i = 0; i < 32; i++)
        {
            if ((n & (1 << i)) != 0)
            {
                ans++;
            }
        }
        return ans;
    }
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        List<IList<int>> ans = new List<IList<int>>(k);
        for (int i = 0; i < Math.Min(nums1.Length, k); i++)
        {
            for (int j = 0; j < Math.Min(nums2.Length, k); j++)
            {
                var a = new List<int>();
                a.Add(nums1[i]);
                a.Add(nums2[j]);
                ans.Add(a);
            }
        }
        return ans.OrderBy(x => x.Sum()).ToList().Take(k).ToList();
    }
    public int MaxDepth(string s)
    {
        var current = 0;
        var max = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                current++;
                max = max > current ? max : current;
            }
            if (s[i] == ')')
            {
                current--;
            }
        }
        return max;
    }
    public bool CheckPerfectNumber(int num)
    {
        if (num == 1)
        {
            return false;
        }

        int sum = 1;
        for (int i = 2; i * i <= num; ++i)
        {
            if (num % i == 0)
            {
                sum += i;
                if (i * i < num)
                {
                    sum += num / i;
                }
            }
        }
        return sum == num;
    }
    public int EatenApples(int[] apples, int[] days)
    {
        PriorityQueue<int[], int> q = new PriorityQueue<int[], int>();
        int n = apples.Length, time = 0, ans = 0;
        while (time < n || q.Count != 0)
        {
            if (time < n && apples[time] > 0)
            {
                q.Enqueue(new int[] { time + days[time] - 1, apples[time] }, time + days[time] - 1);
            }
            while (q.Count > 0 && q.Peek()[0] < time)
            {
                q.Dequeue();
            }
            if (q.Count > 0)
            {
                int[] cur = q.Peek();
                q.Dequeue();
                if (--cur[1] > 0 && cur[0] > time) q.Enqueue(cur, cur[0]);
                ans++;
            }
            time++;
        }
        return ans;
    }
    public bool DetectCapitalUse(string word)
    {
        return word.ToUpper() == word || word.ToLower() == word;
        // 65-90 Upper
        // 97-122 Lower
        var valid = new Regex(@"(^[A-Z]*$|^[a-z]*$|(^[A-Z][a-z]*$))");
        return valid.IsMatch(word);
    }
    public string[] FindWords(string[] words)
    {
        var valid1 = new Regex("^[asdfghjkl]*$");
        var valid2 = new Regex("^[qwertyuiop]*$");
        var valid3 = new Regex("^[zxcvbnm]*$");
        var result = new List<string>();
        foreach (var item in words)
        {
            if (valid1.IsMatch(item.ToLower()) ||
               valid2.IsMatch(item.ToLower()) ||
               valid3.IsMatch(item.ToLower()))
            {
                result.Add(item);
            }
        }
        return result.ToArray();
    }
    public int RobotSim(int[] commands, int[][] obstacles)
    {
        int[] dx = new int[] { 0, 1, 0, -1 };
        int[] dy = new int[] { 1, 0, -1, 0 };
        // 1+Y 2+X 3-Y 4-X
        var currentDirec = 1;
        var X = 0;
        var Y = 0;
        var obstacleSet = new HashSet<long>();
        foreach (var obstacle in obstacles)
        {
            long ox = (long)obstacle[0] + 30000;
            long oy = (long)obstacle[1] + 30000;
            obstacleSet.Add((ox << 16) + oy);
        }

        int ans = 0;
        foreach (int command in commands)
        {
            if (command == -1)
            {
                currentDirec = (currentDirec + 1) % 4;
                continue;
            }
            if (command == -2)
            {
                currentDirec = (currentDirec + 3) % 4;
                continue;
            }
            for (int k = 0; k < command; ++k)
            {
                int nx = X + dx[currentDirec];
                int ny = Y + dy[currentDirec];
                long code = (((long)nx + 30000) << 16) + ((long)ny + 30000);
                if (!obstacleSet.Contains(code))
                {
                    X = nx;
                    Y = ny;
                    ans = Math.Max(ans, X * X + Y * Y);
                }
            }
        }
        return ans;
    }
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var res = new List<IList<int>>();
        if (root == null) return res;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            int len = queue.Count;
            var level = new List<int>();

            for (int i = 0; i < len; i++)
            {
                var t = queue.Dequeue();
                level.Add(t.val);
                if (t.left != null) queue.Enqueue(t.left);
                if (t.right != null) queue.Enqueue(t.right);
            }
            res.Add(level);
        }
        return res;
    }
    public int NumWaterBottles(int numBottles, int numExchange)
    {
        if (numBottles < numExchange)
        {
            return numBottles;
        }
        var a = numBottles / numExchange;
        var b = numBottles % numExchange;
        var c = a;
        if ((a + b) >= numExchange)
        {
            c += b;
        }
        if (c >= numExchange)
        {
            return NumWaterBottles(c, numExchange) + numBottles - b;
        }
        return a + numBottles;
    }
    public bool WordPattern(string pattern, string s)
    {
        var words = s.Split(' ');
        if (pattern.Length != words.Length)
        {
            return false;
        }
        var charMapWord = new Dictionary<char, string>();
        for (int i = 0; i < pattern.Length; i++)
        {
            char tmp = pattern[i];
            if (charMapWord.ContainsKey(tmp))
            {
                charMapWord.TryGetValue(tmp, out string tempWord);
                if (tempWord != words[i]) return false;
            }
            else
            {
                if (charMapWord.ContainsValue(words[i]))
                {
                    return false;
                }
                else
                {
                    charMapWord[tmp] = words[i];
                }
            }
        }

        return true;
    }
    public string ShortestCompletingWord(string licensePlate, string[] words)
    {
        int[] cnt = new int[26];
        var accectCharacter = licensePlate.ToLower().ToCharArray().Where(x => char.IsLetter((char)x)).Select(x => x).ToList();
        foreach (var item in accectCharacter)
        {
            ++cnt[item - 'a'];
        }

        foreach (var item in words.OrderBy(x => x.Length))
        {
            int[] wordsCnt = new int[26];
            var wordsCharacter = item.ToLower().ToCharArray().Where(x => char.IsLetter((char)x)).Select(x => x).ToList();
            foreach (var wordChar in wordsCharacter)
            {
                ++wordsCnt[wordChar - 'a'];
            }

            var isAccect = true;
            for (int i = 0; i < 26; i++)
            {
                if (wordsCnt[i] < cnt[i])
                {
                    isAccect = false;
                }
            }
            if (isAccect)
            {
                return item;
            }
        }
        return "";
    }
    public int LargestSumAfterKNegations(int[] nums, int k)
    {
        if (nums.Length == 0)
        {
            return 0;
        }
        var DYLing = nums.Where(x => x > 0).OrderBy(x => x).ToList();
        var XYLing = nums.Where(x => x <= 0).Select(x => Math.Abs(x)).OrderByDescending(x => x).ToList();
        if (k <= XYLing.Count)
        {
            for (int i = 0; i < k; i++)
            {
                DYLing.Add(XYLing[i]);
            }
            XYLing.RemoveRange(0, k);
            return DYLing.Sum() - XYLing.Sum();
        }
        else
        {
            DYLing.AddRange(XYLing);
            DYLing = DYLing.OrderBy(x => x).ToList();
            k = k - XYLing.Count;
            if (k % 2 == 0)
            {
                return DYLing.Sum();
            }
            else
            {
                return DYLing.Sum() - DYLing.OrderBy(x => x).FirstOrDefault() - DYLing.OrderBy(x => x).FirstOrDefault();
            }
        }
    }
}
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
public class Bank
{
    private Dictionary<int, long> accounts = new Dictionary<int, long>();
    public Bank(long[] balance)
    {
        for (int i = 0; i < balance.Length; i++)
        {
            accounts[i + 1] = balance[i];
        }
    }

    public bool Transfer(int account1, int account2, long money)
    {
        accounts.TryGetValue(account1, out long balance);
        var success = false;
        if (this.Withdraw(account1, money))
        {
            if (!this.Deposit(account2, money))
            {
                this.Deposit(account1, money);
            }
            else
            {
                success = true;
            }
        }
        return success;
    }

    public bool Deposit(int account, long money)
    {
        if (!accounts.ContainsKey(account))
        {
            return false;
        }
        accounts[account] = accounts[account] + money;
        return true;
    }

    public bool Withdraw(int account, long money)
    {
        if (!accounts.ContainsKey(account))
        {
            return false;
        }
        accounts.TryGetValue(account, out long balance);

        if (balance >= money)
        {
            accounts[account] = balance - money;
            return true;
        }
        return false;
    }
}

public class Node
{
    public int val;
    public Node left;
    public Node right;
    public Node next;
    public IList<Node> children;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, IList<Node> _children)
    {
        val = _val;
        children = _children;
    }
}
public class MyCircularQueue
{
    private int Tail { get; set; }
    private int Head { get; set; }
    private int Size { get; set; }
    private int[] Queue { get; set; }

    public MyCircularQueue(int k)
    {
        Tail = 0;
        Head = 0;
        Size = k + 1;
        Queue = new int[k + 1];
    }

    public bool EnQueue(int value)
    {
        if (IsFull())
        {
            return false;
        }
        Queue[(Tail + 1) % Size] = value;
        Tail = (Tail + 1) % Size;
        return true;
    }

    public bool DeQueue()
    {
        if (IsEmpty())
        {
            return false;
        }
        Head = (Head + 1) % Size;
        return true;

    }

    public int Front()
    {
        if (IsEmpty())
        {
            return -1;
        }
        return Queue[(Head + 1) % Size];
    }

    public int Rear()
    {
        if (IsEmpty())
        {
            return -1;
        }
        return Queue[Tail];
    }

    public bool IsEmpty()
    {
        return Tail == Head;
    }

    public bool IsFull()
    {
        return (Tail + 1) % Size == Head;
    }
}
public class QuadTreeNode
{
    public bool val;
    public bool isLeaf;
    public QuadTreeNode topLeft;
    public QuadTreeNode topRight;
    public QuadTreeNode bottomLeft;
    public QuadTreeNode bottomRight;

    public QuadTreeNode()
    {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }

    public QuadTreeNode(bool _val, bool _isLeaf)
    {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }

    public QuadTreeNode(bool _val, bool _isLeaf, QuadTreeNode _topLeft, QuadTreeNode _topRight, QuadTreeNode _bottomLeft, QuadTreeNode _bottomRight)
    {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
