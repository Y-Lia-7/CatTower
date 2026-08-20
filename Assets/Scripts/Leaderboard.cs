using UnityEngine;
using TMPro;

public class EndScene : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] LBDisplay leaderboardDisplay;

    private float finalTime;

    private void Start()
    {
        finalTime = PlayerPrefs.GetFloat("CurrentTime");

        int minutes = Mathf.FloorToInt(finalTime / 60);
        int seconds = Mathf.FloorToInt(finalTime % 60);

        timeText.text = string.Format(
            "Your time: {0:00}:{1:00}",
            minutes,
            seconds
        );
    }

    public void SaveScore()
    {
        string playerName = nameInput.text;

        if (string.IsNullOrWhiteSpace(playerName))
        {
            playerName = "Player";
        }

        LBManager.Instance.AddEntry(playerName, finalTime);

        // Refresh the leaderboard immediately
        leaderboardDisplay.DisplayLeaderboard();
    }
}