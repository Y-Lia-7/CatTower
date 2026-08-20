using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LBManager : MonoBehaviour
{
    public static LBManager Instance;

    public List<LBEntry> entries = new List<LBEntry>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadLeaderboard();
    }

    public void AddEntry(string playerName, float time)
    {
        LBEntry newEntry = new LBEntry(playerName, time);

        entries.Add(newEntry);

        // Sort fastest times first
        entries = entries.OrderBy(entry => entry.time).ToList();

        // Keep only the 10 fastest times
        if (entries.Count > 10)
        {
            entries.RemoveAt(entries.Count - 1);
        }

        SaveLeaderboard();
    }

    private void SaveLeaderboard()
    {
        string json = JsonUtility.ToJson(new LeaderboardData(entries));
        PlayerPrefs.SetString("Leaderboard", json);
        PlayerPrefs.Save();
    }

    private void LoadLeaderboard()
    {
        if (PlayerPrefs.HasKey("Leaderboard"))
        {
            string json = PlayerPrefs.GetString("Leaderboard");

            LeaderboardData data = JsonUtility.FromJson<LeaderboardData>(json);

            entries = data.entries;
        }
    }

    [System.Serializable]
    private class LeaderboardData
    {
        public List<LBEntry> entries;

        public LeaderboardData(List<LBEntry> entries)
        {
            this.entries = entries;
        }
    }

    public void ClearLeaderboard()
{
    entries.Clear();

    PlayerPrefs.DeleteKey("Leaderboard");
    PlayerPrefs.Save();


}

}