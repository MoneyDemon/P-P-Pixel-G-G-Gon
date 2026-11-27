using UnityEngine;

public class EasyEnemy : EnemyBase
{
    private EnemyManager _enemyManager;

    protected override void Start()
    {
        base.Start();

        _enemyManager = FindFirstObjectByType<EnemyManager>();
    }

    protected override void Update()
    {
        base.Update();

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}