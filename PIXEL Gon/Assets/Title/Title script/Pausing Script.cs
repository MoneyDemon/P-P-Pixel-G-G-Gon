using UnityEngine;

public class PausingScript : MonoBehaviour
{
    [SerializeField] public GameObject _pausingMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pausingMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
