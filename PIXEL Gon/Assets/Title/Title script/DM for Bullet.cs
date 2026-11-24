using UnityEngine;

public class DMforBullet : MonoBehaviour
{
   public int CurrentDamage = 2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyBase _enemy = collision.gameObject.GetComponent<EnemyBase>();
            _enemy._health -= CurrentDamage;
            Debug.Log($"Deal {CurrentDamage}");
        }
    }
}
