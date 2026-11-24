using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField] private float _detectionRange = 10f;
    [SerializeField] private List<GameObject> _bullet;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private float _TurretCD = 15f;
    [SerializeField] private float _TurretLastFor = 15f;
    float _currentTurretCD = 0f;
    float _currentTurretLastFor = 0f;
    int _currentBulletUpgrade = 0;
    bool _fired = false;
    private void Awake()
    {
        _currentTurretLastFor = _TurretLastFor;
        _currentTurretCD = _TurretCD;
    }
    void Update()
    {
        #region Start counting down (last and CD)
        _currentTurretLastFor -= Time.deltaTime;
        if (_currentTurretLastFor <= 0)
        {
            _currentTurretLastFor = 0;
            _currentTurretCD -= Time.deltaTime;
            if (_currentTurretCD <= 0)
            {
                _currentTurretLastFor = _TurretLastFor;
                _currentTurretCD = _TurretCD;
            }
        }
        #endregion
        #region Target Closest Enemy with Tag Enemy
        GameObject[] _enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Transform _closestEnemy = null;
        float _closestDistance = Mathf.Infinity;

        foreach(GameObject enemy in _enemies)
        {
            float _distance = Vector2.Distance(transform.position, enemy.transform.position);
            if(_distance < _closestDistance)
            {
                _closestDistance = _distance;
                _closestEnemy = enemy.transform;
            }
        }
        #endregion
        #region if Enemy exist within range and Condition Fire!
        if ( _closestEnemy != null && _closestDistance <= _detectionRange && _currentTurretLastFor > 0f)
        {
            TargetEnemy(_closestEnemy);
            if(_fired == false)
            {
                _fired = true;
                StartCoroutine(WaitForSecondToFire(_fireRate, _closestEnemy));
            } 
        }
        #endregion
    }
    #region Target Enemy Medthod
    private void TargetEnemy(Transform enemyPo)
    {
        Vector2 _direction = enemyPo.position - transform.position;
        float _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }
    #endregion
    #region Wait to fire IENU
    IEnumerator WaitForSecondToFire(float seconds, Transform enemyPosition)
    {
      yield return new WaitForSeconds(seconds);
      GameObject currentBullet = Instantiate(_bullet[_currentBulletUpgrade], transform.position, Quaternion.identity); 
      ShootingBulletforTurret _bulletScript = currentBullet.GetComponent<ShootingBulletforTurret>();
        _bulletScript.SetTarget(enemyPosition);
      _fired = false;
    }
    #endregion
}
