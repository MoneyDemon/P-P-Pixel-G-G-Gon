using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Transform _spawnPoint;
    [SerializeField] EnemyManager _enemyManager;

    private float _timer = 1f;
   
    private void Update()
    {
        _timer -= Time.deltaTime;
        if(_enemyManager.CanSpawnEnemy && _timer <= 0)
        {
            Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);
            _enemyManager.RegisterEnemySpawn();
            _timer = 1f;
        }
    }
}