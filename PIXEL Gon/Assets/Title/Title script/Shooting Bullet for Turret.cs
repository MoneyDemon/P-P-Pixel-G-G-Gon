using UnityEngine;

public class ShootingBulletforTurret : MonoBehaviour
{
    [SerializeField] private float _speed = 15f;
    private Transform _target;
    Vector3 _direction;
    float _angle;

    private void Start()
    {
        if( _target == null)
        {
            Destroy(gameObject);
            return;
        }
        _direction = _target.position - transform.position;
       _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg - 90f;
       
    }
    private void Update()
    {
        transform.position += _direction.normalized * _speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, 0f, _angle);
    }
    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
