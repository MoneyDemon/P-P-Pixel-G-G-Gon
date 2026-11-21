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
    int _currentBulletUpgrade = 0;
    bool _fired = false;
    
    void Update()
    {
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
        if( _closestEnemy != null && _closestDistance <= _detectionRange)
        {
            TargetEnemy(_closestEnemy);
            if(_fired == false)
            {
                _fired = true;
                StartCoroutine(WaitForSecondToFire(_fireRate));
            } 
        }
 
    }
    private void TargetEnemy(Transform enemyPo)
    {
        Vector2 _direction = enemyPo.position - transform.position;
        float _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }
    #region Wait to fire IENU
    IEnumerator WaitForSecondToFire(float seconds)
    {
      yield return new WaitForSeconds(seconds);
      Instantiate(_bullet[_currentBulletUpgrade], transform.position, Quaternion.identity);  
      _fired = false;
    }
    #endregion
}
