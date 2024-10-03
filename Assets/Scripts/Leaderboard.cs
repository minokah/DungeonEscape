using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Leaderboard
{

    private static Dictionary<string, float> entries;

    public static Dictionary<string, float> GetScores()
    {
        if (entries == null)
        {
            entries = new Dictionary<string, float>();
            string data = PlayerPrefs.GetString("Leaderboard");

            if (!data.Equals(""))
            {
                string[] items = data.Split(';');

                foreach (string s in items)
                {
                    string[] item = s.Split(":");
                    entries.Add(item[0], float.Parse(item[1]));
                }
            }
        }

        return entries;
    }

    public static void Sort()
    {
        GetScores();
        entries = entries.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
    }

    public static float GetScore(string name)
    {
        GetScores();
        if (entries.ContainsKey(name)) return entries[name];
        else return -1;
    }

    public static bool AddScore(string name, float time)
    {
        GetScores();

        if (entries.ContainsKey(name)) entries.Remove(name);
        entries.Add(name, time);

        Sort();

        List<string> items = new List<string>();
        foreach ((string s, float v) in entries)
        {
            items.Add($"{s}:{v.ToString("#.##")}");
        }

        PlayerPrefs.SetString("Leaderboard", string.Join(";", items));

        return true;
    }

    public static void Clear()
    {
        PlayerPrefs.DeleteKey("Leaderboard");
        PlayerPrefs.SetString("Leaderboard", "");
    }
}
