using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private bool _canSpawnEnemy;
    private float _enemyCount = 0;
    private float _wave = 0;
    private float _maxEnemyCount;
    

    public bool CanSpawnEnemy => _canSpawnEnemy;
    

    private void Update()
    {
        _maxEnemyCount = Mathf.RoundToInt(5 + _wave * 1.5f);
       
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
