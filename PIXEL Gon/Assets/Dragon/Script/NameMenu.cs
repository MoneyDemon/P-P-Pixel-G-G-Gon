using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NameMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameInput;
    [SerializeField] private int _sceneTndex;

    public void ContinueToGame()
    {
        PlayerPrefs.SetString("PlayerName", _nameInput.text);
        PlayerPrefs.Save();
        SceneManager.LoadScene(_sceneTndex);

        Debug.Log($"Name Saved: {_nameInput.text}");
    }
}