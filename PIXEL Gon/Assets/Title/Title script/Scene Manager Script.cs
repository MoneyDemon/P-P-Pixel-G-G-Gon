using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] public GameObject _pausingMenu;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Resume()
    {
        _pausingMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
