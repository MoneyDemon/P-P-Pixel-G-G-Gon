using UnityEngine;

public class EasyEnemy : EnemyBase
{
    private EnemyManager _enemyManager;

    private void Start()
    {
        // Searches the active scene for the EnemyManager script
        _enemyManager = FindFirstObjectByType<EnemyManager>();
    }
    void Update()
    {
        if (_health <= 0)
        {
            Destroy(this.gameObject);
            
        }
    }
}
