using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] GameObject _tower;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed = 5;
    [SerializeField] float _knockBackForce = 5;
    [SerializeField] float _knockBackDuration = 0.1f;

    public float _health;


    private void FixedUpdate()
    {
        Vector2 dir = (_tower.transform.position - _rb.transform.position).normalized;
        transform.Translate(dir * _speed * Time.deltaTime);
    }

    private void Update()
    {
        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Tower"))
        {
            _health--;
            KnockBack();
        }
    }

    private void KnockBack()
    {
        Vector2 dir = (_tower.transform.position - _rb.transform.position).normalized * -1;
        _rb.linearVelocity = dir * _knockBackForce * Time.deltaTime;
        Debug.Log("KNOCKBACK");
    }
}
