using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private bool _canSpawnEnemy;
    private float _enemyCount = 0;
    private float _maxEnemyCount = 10;
    private float _wave = 0;

    public bool CanSpawnEnemy => _canSpawnEnemy;
    

    private void Update()
    {
        if (_enemyCount == 0)
        {
            _wave++;
            _canSpawnEnemy = true;
        }

      
        if (_enemyCount >= _maxEnemyCount)
        {
            _canSpawnEnemy = false;
            _enemyCount = 0;
        }
    }

  
    public void RegisterEnemySpawn()
    {
        _enemyCount++;
    }

   
    public void RegisterEnemyDeath()
    {
        _enemyCount--;
    }
}
