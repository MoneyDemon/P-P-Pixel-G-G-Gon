using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NameMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameInput;
    [SerializeField] private int _gameSceneNumber;

    public void ContinueToGame()
    {
        string _playerName = _nameInput.text;

        Debug.Log($"Player entered name: {_playerName}");

        PlayerPrefs.SetString("PlayerName", _playerName);
        PlayerPrefs.Save();

        SceneManager.LoadScene(_gameSceneNumber);
    }
}