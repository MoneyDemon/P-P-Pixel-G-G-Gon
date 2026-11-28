using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public float _towerHealth = 100;

    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private SaveManager _saveManager;

    private void Start()
    {
        _saveManager = FindFirstObjectByType<SaveManager>();
    }
    private void Update()
    {
        _healthSlider.value = _towerHealth / 100;
        _healthText.text = Mathf.CeilToInt(_towerHealth).ToString();

        if (_towerHealth <= 0)
        {
            SaveData _saveData = _saveManager.LoadGame();

            int _savedWave = 0;

            if (_saveData != null)
            {
                _savedWave = _saveData._highestWave;
            }

            if (_enemyManager.CurrentWave > _savedWave)
            {
                string _playerName =
                    PlayerPrefs.GetString("PlayerName", "Nobody");

                _saveManager.SaveGame(
                    _playerName,
                    _enemyManager.CurrentWave
                );
            }

            Destroy(gameObject);
        }
    }

   
}