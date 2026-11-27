using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] GameObject _tower;
    [SerializeField] Rigidbody2D _rb;

    [SerializeField] float _speed = 5f;
    public float _health = 5f;

    [SerializeField] float _knockBackDistance = 1.5f;
    [SerializeField] float _knockBackDuration = 0.1f;

    private Transform _target;

    private bool _isKnockedBack;

    private float _targetTimer;
    private const float _targetRefreshRate = 0.25f;

    protected virtual void Start()
    {
        FindTarget();
    }

    protected virtual void Update()
    {
        _targetTimer += Time.deltaTime;

        if (_targetTimer >= _targetRefreshRate)
        {
            FindTarget();
            _targetTimer = 0f;
        }
    }

    private void FixedUpdate()
    {
        if (_isKnockedBack) return;
        if (_target == null) return;

        Vector2 _direction =
            (_target.position - transform.position).normalized;

        _rb.linearVelocity = _direction * _speed;
    }

    private void FindTarget()
    {
        
        GameObject[] _walls = GameObject.FindGameObjectsWithTag("Wall");

        float _towerDistance =
            Vector2.Distance(transform.position, _tower.transform.position);

        GameObject _wall = null;
        float _wallDistance = Mathf.Infinity;

        foreach (GameObject wall in _walls)
        {
            if (wall == null) continue;

            float _distance =
                Vector2.Distance(transform.position, wall.transform.position);

            if (_distance < _wallDistance)
            {
                _wallDistance = _distance;
                _wall = wall;
            }
        }

        if (_wall != null && _wallDistance < _towerDistance)
        {
            _target = _wall.transform;
        }
        else
        {
            _target = _tower.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tower") || collision.gameObject.CompareTag("Wall"))
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