using UnityEngine;
using TMPro;

public class LBDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI leaderboardText;

    private void Start()
    {
        DisplayLeaderboard();
    }

    public void DisplayLeaderboard()
    {
        leaderboardText.text = "";

        for (int i = 0; i < LBManager.Instance.entries.Count; i++)
        {
            LBEntry entry = LBManager.Instance.entries[i];

            int minutes = Mathf.FloorToInt(entry.time / 60);
            int seconds = Mathf.FloorToInt(entry.time % 60);

            string formattedTime =
                string.Format("{0:00}:{1:00}", minutes, seconds);

            leaderboardText.text +=
                $"{i + 1}. {entry.playerName} - {formattedTime}\n";
        }
    }

    public void ClearLeaderboard()
    {
        if (LBManager.Instance != null)
        {
            LBManager.Instance.ClearLeaderboard();
            DisplayLeaderboard();
        }
    }
}