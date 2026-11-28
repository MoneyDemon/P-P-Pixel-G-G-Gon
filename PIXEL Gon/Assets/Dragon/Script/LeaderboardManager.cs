using TMPro;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _leaderboardText;

    private void Start()
    {
        UpdateLeaderboard();
    }

    public void UpdateLeaderboard()
    {
        string _playerName = PlayerPrefs.GetString("PlayerName", "Nobody");
        int _highestWave = PlayerPrefs.GetInt("HighestWave", 0);

        Debug.Log($"Loaded Name: {_playerName}");
        Debug.Log($"Loaded Highest Wave: {_highestWave}");

        _leaderboardText.text =
            $"Best Player: {_playerName}\nHighest Wave: {_highestWave}";
    }
}