using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class KnockBackEnemy : EnemyBase
{
    [SerializeField] float _knockBackDistance = 1.5f;
    [SerializeField] float _knockBackDuration = 0.1f;
    [SerializeField] float _damage = 2;
    private bool _isKnockedBack;
    



    protected override void Update()
    {
        base.Update();

        if (_health <= 0)
        {
            Destroy(gameObject);
            _enemyManager.EnemyDeathCount();
        }
        
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (_isKnockedBack) return;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tower") || collision.gameObject.CompareTag("Wall"))
        {
            _health--;
            _towerHealth._towerHealth -= _damage;
            Debug.Log($"Hit {_towerHealth}");

            if (!_isKnockedBack)
            {
                StartCoroutine(KnockBack());
            }
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            _wallHealth._health -= _damage;
        }
    }

    private IEnumerator KnockBack()
    {

        _isKnockedBack = true;
        
        _rb.linearVelocity = Vector2.zero;

        Vector2 _startPos = _rb.position;

        Vector2 _direction =
            (_rb.position - (Vector2)_tower.transform.position).normalized;

        Vector2 _endPos =
            _startPos + _direction * _knockBackDistance;

        float _elapsed = 0f;

        while (_elapsed < _knockBackDuration)
        {
            _rb.MovePosition(
                Vector2.Lerp(
                    _startPos,
                    _endPos,
                    _elapsed / _knockBackDuration
                )
            );

            _elapsed += Time.deltaTime;
            yield return null;
        }

        _rb.MovePosition(_endPos);

        _isKnockedBack = false;
    }
}