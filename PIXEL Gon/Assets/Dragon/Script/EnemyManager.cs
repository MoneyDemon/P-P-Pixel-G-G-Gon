using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private bool _canSpawnEnemy;

    private int _aliveEnemyCount;
    private int _spawnedEnemyCount;

    private int _wave;
    private int _maxEnemyCount;

    private float _timer = 10f;

    [SerializeField] private TMP_Text _waveCountText;
    [SerializeField] private TMP_Text _aliveEnemyText;

    public bool CanSpawnEnemy => _canSpawnEnemy;

    private void Start()
    {
        StartNextWave();
    }

    private void Update()
    {
      _aliveEnemyText.text = $"Current Enemy Count:{_aliveEnemyCount}";
        if (!_canSpawnEnemy && _aliveEnemyCount <= 0 && _spawnedEnemyCount >= _maxEnemyCount)
        {
            _timer -= Time.deltaTime;

            _waveCountText.text = $"Wave {_wave} Complete\nNext Wave In: {Mathf.CeilToInt(_timer)}";

            if (_timer <= 0)
            {
                StartNextWave();
            }
        }
    }

    private void StartNextWave()
    {
        _wave++;

        _spawnedEnemyCount = 0;
        _aliveEnemyCount = 0;

        _maxEnemyCount = Mathf.RoundToInt(5 + _wave * 1.5f);

        _canSpawnEnemy = true;
        _timer = 10f;

        _waveCountText.text = $"Current Wave: {_wave}";

        
    }

    public void EnemySpawnCount()
    {
        _aliveEnemyCount++;
        _spawnedEnemyCount++;

        

      
        if (_spawnedEnemyCount >= _maxEnemyCount)
        {
            _canSpawnEnemy = false;
        }
    }

    public void EnemyDeathCount()
    {
        _aliveEnemyCount--;


        if (_aliveEnemyCount < 0)
        {
            _aliveEnemyCount = 0;
        }
    }
}