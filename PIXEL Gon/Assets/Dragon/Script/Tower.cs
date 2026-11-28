using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public float _towerHealth = 100;

    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private EnemyManager _enemyManager;

    private void Update()
    {
        _healthSlider.value = _towerHealth / 100;
        _healthText.text = Mathf.CeilToInt(_towerHealth).ToString();

        if (_towerHealth <= 0)
        {
            SaveHighWave();

            Debug.Log("GGsEz");
            Destroy(gameObject);
        }
    }

    private void SaveHighWave()
    {
        int _currentWave = _enemyManager.CurrentWave;
        int _highestWave = PlayerPrefs.GetInt("HighestWave", 0);

        Debug.Log($"Current Wave: {_currentWave}");
        Debug.Log($"Saved Highest Wave: {_highestWave}");

        if (_currentWave > _highestWave)
        {
            PlayerPrefs.SetInt("HighestWave", _currentWave);
            PlayerPrefs.Save();

            Debug.Log($"NEW RECORD SAVED! Wave {_currentWave}");
        }
    }
}