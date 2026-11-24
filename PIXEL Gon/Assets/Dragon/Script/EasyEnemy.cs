using UnityEngine;

public class EasyEnemy : EnemyBase
{

    void Update()
    {
        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
