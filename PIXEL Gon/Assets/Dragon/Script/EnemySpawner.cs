using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private EnemyManager _enemyManager;

    private float _timer = 1f;

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_enemyManager.CanSpawnEnemy && _timer <= 0f)
        {
            Instantiate( _enemyPrefab, _spawnPoint.position, Quaternion.identity);

            _enemyManager.EnemySpawnCount();

            _timer = 1f;
        }
    }
}