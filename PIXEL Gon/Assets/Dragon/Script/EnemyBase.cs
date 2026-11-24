using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] GameObject _tower;
    [SerializeField] Rigidbody2D _rb;
    
    [SerializeField] float _speed = 5f;
    [SerializeField] float _knockBackDistance = 1.5f;
    [SerializeField] float _knockBackDuration = 0.1f;

    public float _health;

    bool _isKnockedBack;

    private void FixedUpdate()
    {
        if (_isKnockedBack) return;

        Vector2 _dir = (_tower.transform.position - transform.position).normalized;
        _rb.linearVelocity = _dir * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            _health--;

            if (!_isKnockedBack)
            {
                StartCoroutine(KnockBack());
            }
        }
    }

    private IEnumerator KnockBack()
    {
        _isKnockedBack = true;

        Vector2 _startPos = transform.position;
        Vector2 _dir = (_rb.position - (Vector2)_tower.transform.position).normalized;
        Vector2 _endPos = _startPos + _dir * _knockBackDistance;

        float _elapsed = 0;

        while (_elapsed < _knockBackDuration)
        {
            transform.position = Vector2.Lerp(
                _startPos,
                _endPos,
                _elapsed / _knockBackDuration
            );

            _elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = _endPos;

        _isKnockedBack = false;
    }
}