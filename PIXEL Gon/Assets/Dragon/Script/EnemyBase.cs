using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public GameObject _tower;
    public Rigidbody2D _rb;
    public float _health = 5f;
    public Tower _towerHealth;
    public EnemyManager _enemyManager;
    public WallHealth _wallHealth;
    [SerializeField] float _speed = 5f;
    private Transform _target;
    private float _targetTimer;
    private const float _targetRefreshRate = 0.25f;
    

    protected virtual void Start()
    {
        FindTarget();
        _enemyManager = FindFirstObjectByType<EnemyManager>();
        _towerHealth = FindFirstObjectByType<Tower>();

    }

    protected virtual void Update()
    {
        _targetTimer += Time.deltaTime;

        if (_targetTimer >= _targetRefreshRate)
        {
            FindTarget();
            _targetTimer = 0f;
        }
        _wallHealth = FindAnyObjectByType<WallHealth>();
    }

    protected virtual void FixedUpdate()
    {
        
        if (_target == null) return;

        Vector2 _direction =
            (_target.position - transform.position).normalized;

        _rb.linearVelocity = _direction * _speed;
    }

    protected virtual void FindTarget()
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

    

   
}