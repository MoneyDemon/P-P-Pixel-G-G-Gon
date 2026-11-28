using TMPro;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameInput;
    [SerializeField] private TMP_Text _recordText;

    private void Start()
    {
        LoadRecord();

        // Load saved name back into input field
        _nameInput.text = PlayerPrefs.GetString("PlayerName", "");
    }

    public void SavePlayerName()
    {
        PlayerPrefs.SetString("PlayerName", _nameInput.text);
        PlayerPrefs.Save();
    }

    public void SaveWave(int _waveNumber)
    {
        int _highestWave = PlayerPrefs.GetInt("HighestWave", 0);

        if (_waveNumber > _highestWave)
        {
            PlayerPrefs.SetString("PlayerName", _nameInput.text);
            PlayerPrefs.SetInt("HighestWave", _waveNumber);

            PlayerPrefs.Save();

            LoadRecord();
        }
    }

    private void LoadRecord()
    {
        string _playerName = PlayerPrefs.GetString("PlayerName", "Nobody");
        int _highestWave = PlayerPrefs.GetInt("HighestWave", 0);

        _recordText.text =
            $"Best Player: {_playerName}\nHighest Wave: {_highestWave}";
    }
}