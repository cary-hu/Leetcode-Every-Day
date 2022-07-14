using System.Text;
/// <summary>
/// 20220714
/// https://leetcode.cn/problems/prefix-and-suffix-search/
/// </summary>
public class WordFilter
{
    private Dictionary<string, int> dictionary = new Dictionary<string, int>();
    public WordFilter(string[] words)
    {
        for (int i = 0; i < words.Length; i++)
        {
            var item = words[i];
            for (int j = 1; j <= item.Length; j++)
            {
                for (int k = 1; k <= item.Length; k++)
                {

                    var fixItem = item.Substring(0, j) + '#' + item.Substring(item.Length - k);
                    if (dictionary.ContainsKey(fixItem))
                    {
                        dictionary[fixItem] = i;
                    }
                    else
                    {
                        dictionary.Add(fixItem, i);
                    }
                }
            }

        }
    }

    public int F(string pref, string suff)
    {
        if (dictionary.ContainsKey(pref + "#" + suff))
        {
            return dictionary[pref + "#" + suff];
        }
        return -1;
    }
}

/**
 * Your WordFilter object will be instantiated and called as such:
 * WordFilter obj = new WordFilter(words);
 * int param_1 = obj.F(pref,suff);
 */

public class WordFilterTrie
{
    Trie trie;
    string weightKey;

    public WordFilterTrie(string[] words)
    {
        trie = new Trie();
        weightKey = "##";
        for (int i = words.Length - 1; i >= 0; i--)
        {
            string word = words[i];
            Trie cur = trie;
            string key;
            int m = word.Length;
            for (int j = 0; j < m; j++)
            {
                Trie tmp = cur;
                for (int k = j; k < m; k++)
                {
                    key = new StringBuilder().Append(word[k]).Append('#').ToString();
                    if (!tmp.Children.ContainsKey(key))
                    {
                        tmp.Children.TryAdd(key, new Trie());
                    }
                    tmp = tmp.Children[key];
                    tmp.Weight.TryAdd(weightKey, i);
                }
                tmp = cur;
                for (int k = j; k < m; k++)
                {
                    key = new StringBuilder().Append('#').Append(word[m - k - 1]).ToString();
                    if (!tmp.Children.ContainsKey(key))
                    {
                        tmp.Children.TryAdd(key, new Trie());
                    }
                    tmp = tmp.Children[key];
                    tmp.Weight.TryAdd(weightKey, i);
                }
                key = new StringBuilder().Append(word[j]).Append(word[m - j - 1]).ToString();
                if (!cur.Children.ContainsKey(key))
                {
                    cur.Children.TryAdd(key, new Trie());
                }
                cur = cur.Children[key];
                cur.Weight.TryAdd(weightKey, i);
            }
        }
    }

    public int F(string pref, string suff)
    {
        Trie cur = trie;
        int m = Math.Max(pref.Length, suff.Length);
        for (int i = 0; i < m; i++)
        {
            char c1 = i < pref.Length ? pref[i] : '#';
            char c2 = i < suff.Length ? suff[suff.Length - 1 - i] : '#';
            string key = new StringBuilder().Append(c1).Append(c2).ToString();
            if (!cur.Children.ContainsKey(key))
            {
                return -1;
            }
            cur = cur.Children[key];
        }
        return cur.Weight[weightKey];
    }
}

public class Trie
{
    public Dictionary<string, Trie> Children;
    public Dictionary<string, int> Weight;

    public Trie()
    {
        Children = new Dictionary<string, Trie>();
        Weight = new Dictionary<string, int>();
    }
}