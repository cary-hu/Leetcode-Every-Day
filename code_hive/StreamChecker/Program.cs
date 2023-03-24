using System.Text;
/// <summary>
/// 20230324
/// https://leetcode.cn/problems/stream-of-characters/
/// </summary>
/// 
//var a = new StreamChecker(new string[] { "babbaabababbbbabbaaaaaaabbbbaababbbbabaabbaabaabaabbbabbabbbaabaaabbba", "bbabbbaababbaababbbabaabaabaabbbbaabbaabbaaababbabbbbbabbbbbbbaaaaaabaaabaaaaabbabbbaba", "aaabaaabaabbbaababbbaaabababaaaaababbbbabaaaaaaaabbaabbbaababbbbababbabaababaabababaabaabbababaaa", "abbabbabbbbaaabababbbbaaaaabaaaaaaaaaabbbabbbababbabbb", "bbaabbbaabbaaababbaabaaaabbabbbbababaaabbbbbabaabbaabbaaababbaabbab", "aaaaaababbbbbbbabaaabbabbbaabbaababbbbbbaabbbbababbbbabaabababbabbbbaaabbaababaabaaaaabbbbaa", "baaabbabbbbaabbabbbbbbbbbbaabbabaabbabaaabababbbbaaaabbb", "aaabaabbaabbbabbbaabbabbbbbabaabbabbbabaabbaaabbbaaababaabbabbbabbabaaabbbaaaababbaaaa", "abbaaaababbbbaabbbabaaaaaabbabbabaaaabbbbbaaabaaababaaabababbabbbaabbbabbaaaaaabbbabbabbba", "aaaaaabbaabbbabbaabbabbbaaabaaabababbaaaaababaabbbaabbaabbabbbaabaaaabbbaababaaaaaababa", "bbbabaababbbbbaabbbbaaabbababbbbbbaabbabbaabbbaaabababaabaaaabaa", "babaababaaaaabbbbaaaaabaaababbaaabababbbbaabaabbaaabbb", "aaaabbbbaaaabbaaabbbaaabbbabaabbbaaabaaababaaababaababbbabbaabbaabbbbababbbaaaaaabaabaabbbbbbaba", "aabaabbabbbabaaaababbaaababbabababbabaabbaaabbababbbbaaaaaaabbabbbbaa", "bbabbbbbabaababaabaaabaabbbbbbbaaaabbbbaababaaaaaabababbabbbaabb", "bbbbbabbbabaaabaabbaaaabbbabbbbbbaababbaabaaaabbabaabbbabbbbbbaabababaaabaaaaabaabababaabbabbbabb", "aabaababaababaabbbabbaaabbbbabbbbababbaaaaabaaabaaaaabaaaaaabbabbbbaabb", "babbbabbbabbababbbabaaabbaaaabaabaabaaaabbabbaababbaababaaabaab", "aabaababbabbbabbabababaabbbaaababbbabbbbbbbaababbbbaaabbaaababaaaaabbaabbaababba", "bbbaaaabaaaabbbbbababaabababbabababaaabbbbaaaabbbbbabaaaabbbbbaabbaabbabbabaaaabaabbababbaabbaaaa", "abbabbbbbbaabbabaaabaabbbbbbabbbaaabaabbabbbbaaabbbbbaaaabaaaabaaabbbaaabaaaba", "ababababbbabababbbbbbbbabbbabbbbabbbaabbbbbabbabaabababbbaba", "babbabbbaabbaababbbababaaabbbbbbbaabaabbaaaababbabbbaabbaaaabbbaabaaaabbabaabbaabaabba", "bbaaabbababaaabbaaaabbbbbbaababbaabbaaabbbaaaaabbaabaaabbbabbbaaabaaaaaabbbababbabbbaabbbabbbabbaab", "baabababbbbabaaaaaaaabaaaabaababaaababbbaababbaaabababb", "baaabbabaaaaaabaaabbbaaaaabbababbbaaabbbabbaababbbababaaabbbaaaaaaabaaabbabbabbaaaaababbba", "aaaabbbbaaaabaaabbbbabaabaaabbaaabbbbabbababbbbbbbaaaa", "aaabbaaaabbbaababbabaaabaababbbbaaabababbaabbbaabbaabbbaaaaaab", "aaaabababaaabbbbaabbabaaaabbbbbbaabbaabbaababbaaababbbbabaaa", "babbabaaaaabbabaaaaaaaabababbababaabbbbaaabaabbaabbbbbbaaabbaaabaabbaa", "baaabbbbbababbbbbabbbbbababbabbbbbbbaabbababbaabbbbbaabbbbbababba", "aaaaababaabaaabbaaaaaabbbaaabbababaaabbabaaaaabbbaabbaabaaaabbbbbb", "bbababbbbaaabaaababbaabbaababaaabbaaabbbaaaabaabbaabbabbbababaabaaababbbaabbaaa", "bbbbbabbaababbbaabaabaaabbaabbbababbbbbaabaaaabbaabaaaabaaabaaababaabbbaaaabbabbbabbaab", "abbbabbbababaababaaabaaaabaabbaaabbbaabbbaaaaaabaaababbbbaabaaabaabbaaa", "bbbabaaabaaaaaabbbaaabbbaaaababbabababababaaabbbbbabaabb", "aababbabbbbabbbabbbbbbbbbabaaaaabaaaaababbaaabbbbaababbbaaaaaaa", "aabababaaaababbababbabaaabaaabaaabaabbbaabbaaabbbbbababbaaaabaabbabbabaaaaabbbababababbabaaaabba", "babbabbaabaabbbaaabbabbbababbbbabababbbbbaababbbbabbababbbabaabaababbababababaabaaaaaabbababbaaaabbb", "aaababaaaabbabaabbabaabbbbbabaabbaaabbbabbbaababbaaaabbbabbabbabaababbabbaabaaa", "baaababbbaaabaabbabbbbabbbbaabbaaaaaaaabbaabbabaaaaaabaaaaaaabaaabbaaaabbaabbbbabbb", "aaabbaabaababbabbbbbabbaaaabaabaaaaabaaaabaabaababbaa", "bbbbbbabbaaaaabbababbaabbbaaaababbababaaabaabbabbbaababbbaaaabbbaababababaababba", "aabaabbaaabbbbbaaaaabaababbabaabbbbaabbaaaaaaabbbbbbbaaabbbabaaabbbbababaabbaabaaaabbbbababababbab", "bbbaaaababaaaaababbabbbbbbbbbbaababbaabbaabababababbbabbbbaaabbabbbaaabbbbbbabab", "babaaabbbabbbabbabaabababaabbaaabbbbabbbaaabbbababaaaaabaabbba", "ababbabbabbbbbbaaaabbbbbaaaabbaaaababaaabaabbaaaaaabbaaa", "abbbbbbbbaaaabbbaaaaaaaaabbbaabbaaabaaabbaabaaababbbbbabbababbbbabbabbabbbabbaaababbaabaabab", "bbaaaaababbbbbaabbaabbaabbaaabbaaabbbbbbbbbbaaabaababa", "abaabbaabbabbbbbbbbbbbaaabaabbbbabaaabbbaabbbabbababb", "aabaaaaabbaabbbbbabaabbbabbaababbaaaaaabaaababbabbbbbaaabbaabaababaaaabaab", "bbaaaaaabbabbbbabbbaabaaaaabaabbbabbbaabbbbabbbbaaabbbbbaaabaababbabbabba", "aabbaaaaaaaaaabababaaaabbbbbabbabbaababaabbababbbaabbaabaaabbaababaabaabaabbabaaaaa", "bbbbabbbababbbbaabbabaababbbbbabbbbaaabaaaaaababaababbaaaabaabaababbbbbbababaabbbaabba", "bbbabbaaababbbbbbabaaabaaaaaaaabaaaaabaabbbabbbabbaababbbbbabbbbaaaaabb", "bbaabaabbabbabbbaaabaabaababaaaabbaabbaaaabaaaaabbabbba", "abaaaaaaaababbbabaaabaabbaaabaaaaabababbbabbaabbaa", "abbabbaababaaaaaaaabaabbaaabbbbabaaabaaaabaababbabbaabbaabbaaa", "aaaabbbabbabababbabbbbbbbababbbaabbababbbaaabbaaaa", "aaaaaababaaaabaabbaabbaabababbabbaaaaaabbbbaabbabaabaaabbbbbbaaaaabaabaabbabbaababbbbaaaabbabaab", "abbababbababbbaaabbaabbabbbaaaabbaabaabbaabbbbbabb", "abababbaaabaaabbaababbaabbaaaaaaaabbaaaabababababbaaabbaababbbaabbaabbabbbbbbbaabaa", "abaaabbbbbaaaabbbababababaaaabaabaaaababbababbabab", "aaaabbbaaaababaabaaaaababbabababbaabaabbbaaaabbbbabbaaabababbabbabbbbbaaaaba", "abbbbababbaaaabababbaaabaaaabaabaaaabbbaabababbbbaaabbaabbaababbbaaabbbaaabbaaababbaaabababbba", "abbbbabbbaaaabbabbabaaaabababaaababaabbabaabaababbaabbaaaabbaabba", "babaaabaaaaabaabaabababaaabbabaaababbbbbababaaaababbbbaaaabaaaabbbaaababbbaababbaabaaabaaaabbbaa", "aabbaabbbabaabaabbabbbaabbbbbbaabaabbabbaabababbbaabbbbaaaabbbabaabbaabaab", "ababababbababbaaaababbbbaabbbbbbabbaaabaabbaabababbbaaaabbabaabbbaabbaababbabbabbabaaaaaaaabaaaa", "abaababbabaaabbabaabbbaaabaabababaaaaababababbbaababbbbabbbaabaaababbaabaaaaab", "babaabaabbbabbbbbabbabaabbbaabbaaabbbbbbbbbaabbaaabaabbabaabbaab", "aabbbbaaaaaaabaaaaaabbbababaaaabbabaaabababaabababbabbbabaaaaabbababbbabbaabaabaababbababa", "abbaaaabbabbbaaaabaaaabbaaaabbaabaaababaaaaabbababbbabaabaaabbbaabababbabbbbababbbba", "aaabbbbaabababaaababbabbaabbbbaaaabbbaababbaabaabbaaaaabbaabbbbaaaabbbbabaaaaabbaaababbba", "aaabbabaaaaaabbbaaaaaaabbaaaaaababbbbbaababbabbbbaabaaaaabbbbaaabaababbbaabbabbaaabababba", "abbbbaaabbbabaababbbbaabbbbabababaabbbaaabaaabaabababababbbbbbbaaabbabaaabbbaabababaaabbbbaaba", "aabbbbbaaabbaaabbaabbaaabbbbbaabababbbbbbabbaabbabbaabbaabaaaaabbaaabbaaaabbaabb", "abbbbbbabbabaaabbabaababbbbbaaabbaaaababbaaaabbbbaababbabaaaba", "babaaaaaaaabbbabaaabbbbaaaaaabaabaabbbaaaaaaaababbbbabbabbbbbaaa", "aaabaaabbaaababaabaaaabbaabbbababaaabbabbabaabbbaabaabbbbbaabbbabababbabaabababaabab", "baabaabbbbbabaabbababababaabbabababaabaaabbbbaaaabbbaaaaaabaaabaaaaaaabababbbbaababbaabaaa", "aabbabbaabbbbaaabaaabbbaababaaaabaaabbabbabbbabaaaaaaabaaabaabaaabbaa", "bbbbabbbababaababbaababaabbababaaabaabaabbababaaaabbbabaaaabaababaabaabaaababbabbabbbbabaabbaa", "abbabababaabaabababaabbbaaaabaaaaaabbaaabbaabbaaababbaaaabbbabbabbbbbbaaaabbabbbaabbabbbbbbbaa", "bababbaaaaaabaabbaaabbbabbaababbabbbbaaabbbbabaababaaabbaaaba", "bababbbaaaabbbbbbbaababbaabbbababbaaaaaabaaabbabaabbbabbabbbba", "abbbbabbbbbaabaaabbababbbabababbaabbabbbbbaaaababaabbabaababababbaabababba", "ababaaabbbbbaaaabababbbababbaababbaaabbabbaaabababaabaabbbaaabaabbbaabababaaaaabbbaabaaabaaababaaba", "bbbaabbabbaababababbbbaaaabaababaaaababbaaabababbbbbaaaabaaaaaabbaaaabbbbabb", "bbbabbababbbaaaaabbbababbbabababbbaabbaabbabaaaaaaaaababbbabbbabbabaabaaababaaabbabbabbab", "aaababababbaabababaabbaabbabbabbaaaaabbabbabbbbbabbbaaababbaabaabaabbbbbababbbaabaaba", "baaaaaabbbbabbababbaaabbababbbbbbaabbbbaaaabbabbaabaabbbb", "aaaaabbbaaabbbbbaaabbababaaabbabaaababbbbbabbaaaaabbbbbbaaabbba", "aaabbbbabaabbabbbabababaabbaaabbababbbbaabbabbabaaabbbaaabaa", "abbbabaabbbabbbaaaaabbababbaabaabbaabbababaaaaabbaaabbaabaaababaaabbbabbaab", "abbbaaabbaaabbaaababbababbabbbaaabbaabaaaabbbbabaaaabbba", "bbaabaaaababbaaabaabbbaaaaababaaaaabaaabbaabbbbabaababbaaaaabbbabaabababbbabbbbaaaaa", "abaaaabbabbbaababbaabaaaaaaabbabbbbaababaaabbabaabaaaaaaabbbabbbbbbaabaabbabaaabbabbbabbbabaabaaabbb", "babaaababbaaaababbaabbbbbaabaababbbaabaabababababababbabaabaababbaababaabbabbbbbbaaababaabb", "bbbaaababbabbbababaaabbaabbbaabababbbabbbbbbbbabaaaaa" });
//a.Query('a');
//a.Query('a');
//a.Query('a');
//a.Query('a');
//a.Query('a');
//a.Query('b');
//a.Query('a');
//a.Query('b');
//a.Query('a');
//a.Query('b');
//a.Query('b');
//a.Query('b');
//a.Query('a');
//a.Query('b');
//a.Query('a');
//a.Query('b');
//a.Query('b');
//a.Query('b');
//a.Query('b');
//a.Query('a');
//a.Query('b');
//a.Query('a');
//a.Query('b');
//a.Query('a');
//a.Query('a');
//a.Query('a');
//a.Query('b');
//a.Query('a');
//a.Query('a');
//a.Query('a');
//public class StreamChecker
//{
//    private WordItem trie { get; set; } = new WordItem();
//    private List<char> Queries { get; set; } = new List<char>();
//    public StreamChecker(string[] words)
//    {
//        foreach (var word in words)
//        {
//            AddWordToWordTree(word);
//        }
//    }
//    private void AddWordToWordTree(string word)
//    {
//        var chars = word.ToCharArray().Reverse();
//        var currentWordItem = trie;
//        foreach (char charItem in chars)
//        {
//            var nextWordItem = currentWordItem.Next.Where(x => x.Current == charItem).SingleOrDefault();
//            if (nextWordItem != null)
//            {
//                currentWordItem = nextWordItem;
//            }
//            else
//            {
//                var newWordItem = new WordItem() { Current = charItem, Next = new List<WordItem>() };
//                currentWordItem.Next.Add(newWordItem);
//                currentWordItem = newWordItem;
//            }
//        }
//        currentWordItem.ValidLength.Add(word.Length);
//    }

//    public bool Query(char letter)
//    {
//        Queries.Insert(0, letter);
//        if (trie.Next.Where(x => x.Current == letter).Any())
//        {
//            if (Queries.Count == 14)
//            {

//            }
//            return Find(0, string.Join("", Queries), trie);
//        }
//        return false;
//    }

//    public bool Find(int index, string res, WordItem currentItem)
//    {
//        if (index == res.Length)
//        {
//            if (currentItem.ValidLength.Contains(index))
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }
//        if (!currentItem.Next.Any() && currentItem.ValidLength.Contains(index))
//        {
//            return true;
//        }
//        if(currentItem.ValidLength.Contains(index))
//        {
//            return true;
//        }
//        var next = currentItem.Next.Where(x => x.Current == res[index]).SingleOrDefault();
//        if (next != null)
//        {
//            return Find(index + 1, res, next);
//        }
//        else if (currentItem.ValidLength.Contains(index))
//        {
//            return true;
//        }
//        return false;
//    }
//}

//public class WordItem
//{
//    public char Current { get; set; }
//    public List<WordItem> Next { get; set; } = new List<WordItem>();
//    public List<int> ValidLength { get; set; } = new List<int>();
//}


public class StreamChecker
{
    Node root = new Node();
    StringBuilder sb = new StringBuilder();

    public StreamChecker(string[] words)
    {
        foreach (string word in words)
        {
            Node p = root;
            char[] cs = word.ToCharArray();
            for (int i = cs.Length - 1; i >= 0; i--)
            {
                if (p.childrens[cs[i] - 'a'] == null)
                {
                    p.childrens[cs[i] - 'a'] = new Node();
                }
                p = p.childrens[cs[i] - 'a'];
            }
            p.isWord = true;
        }
    }
    public bool Query(char c)
    {
        sb.Append(c);
        Node p = root;
        for (int i = sb.Length - 1; i >= 0 && p != null; i--)
        {
            p = p.childrens[sb[i] - 'a'];
            if (p != null && p.isWord) return true;
        }
        return false;
    }

}
public class Node
{
    public bool isWord;
    public Node[] childrens = new Node[26];
}