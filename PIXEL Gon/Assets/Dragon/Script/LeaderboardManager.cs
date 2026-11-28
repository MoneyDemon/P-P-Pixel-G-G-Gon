using TMPro;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _leaderboardText;
    [SerializeField] private SaveManager _saveManager;

    private void Start()
    {
        SaveData _saveData = _saveManager.LoadGame();

        if (_saveData != null)
        {
            _leaderboardText.text = $"Best Player: {_saveData._playerName}\nHighest Wave: {_saveData._highestWave}";
        }

        if (_saveData == null)
        {
            _leaderboardText.text = "No High Score";
        }
    }


}