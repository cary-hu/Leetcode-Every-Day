/// <summary>
/// 20251212
/// https://leetcode.cn/problems/count-mentions-per-user/
/// </summary>
public class Solution
{
    public int[] CountMentions(int numberOfUsers, IList<IList<string>> events)
    {
        var groupedEvents = events
            .Select(e => new { EventType = e[0], Timestamp = int.Parse(e[1]), Details = e.Skip(2).ToList() })
            .OrderBy(e => e.Timestamp)
            .ThenBy(e => e.EventType == "OFFLINE" ? 0 : 1) // OFFLINE before MESSAGE if same timestamp
            .Select(e => new List<string> { e.EventType, e.Timestamp.ToString() }.Concat(e.Details).ToList())
            .ToList();

        int[] mentions = new int[numberOfUsers];
        List<(int, int)> offlineUsers = []; // (userId, onlineTime)
        foreach (var e in groupedEvents)
        {
            for (var i = offlineUsers.Count - 1; i >= 0; i--)
            {
                var user = offlineUsers[i];
                if (user.Item2 <= int.Parse(e[1]))
                {
                    offlineUsers.Remove(user);
                }
            }
            if (e[0] == "MESSAGE")
            {
                int timestamp = int.Parse(e[1]);
                List<int> mentionsString = [];
                string[] tokens = e[2].Split(' ');
                foreach (var token in tokens)
                {
                    if (token == "ALL")
                    {
                        for (int i = 0; i < numberOfUsers; i++)
                        {
                            mentions[i]++;
                        }
                    }
                    else if (token == "HERE")
                    {
                        HashSet<int> offlineSet = offlineUsers.Select(u => u.Item1).ToHashSet();
                        for (int i = 0; i < numberOfUsers; i++)
                        {
                            if (!offlineSet.Contains(i))
                            {
                                mentions[i]++;
                            }
                        }
                    }
                    else if (token.StartsWith("id"))
                    {
                        int userId = int.Parse(token.Substring(2));
                        mentions[userId]++;
                    }
                }
            }
            if (e[0] == "OFFLINE")
            {
                int timestamp = int.Parse(e[1]);
                int userId = int.Parse(e[2]);
                // Handle offline event
                offlineUsers.Add((userId, timestamp + 60));
            }
        }
        return mentions;
    }
}