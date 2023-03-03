/// <summary>
/// 20230303
/// https://leetcode.cn/problems/making-file-names-unique/
/// </summary>
public class Solution {
    public string[] GetFolderNames(string[] names) {
        var _dict = new Dictionary<string, int>();
        var n = names.Length;
        var res = new string[n];
        string resName;
        for (int i = 0; i < n; i++) {
            string name = names[i];
            if (!_dict.ContainsKey(name)) {
                resName = name;
            }
            else {
                int k = _dict[name];
                while (_dict.ContainsKey($"{name}({k})")) {
                    k++;
                }
                resName = $"{name}({k})";
                _dict[name] = k + 1;
            }
            res[i] = resName;
            _dict.Add(resName, 1);
        }
        return res;
    }
}