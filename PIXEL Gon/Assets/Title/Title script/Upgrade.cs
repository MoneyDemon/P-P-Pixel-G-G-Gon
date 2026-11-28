using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class DamageSHOW : MonoBehaviour
{
    #region get Game object ref
    [SerializeField] private List<GameObject> _turret;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _tower;
    [SerializeField] private GameObject _ui;
    [SerializeField] private GameObject _turretSpawner;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private EclecticFieldManagerScript _eclecticFieldManager;
    [SerializeField] private WallManager _wallManager;
    #endregion
    
    int _currentTurretUpgrade = 0;
    int _maxUpgrade = 2;
    int _maxUpgradeForBullet = 3;
    int _eclecticFieldSetTrue = 0;

    void Update()
    {
        #region Open UI
        if (Input.GetKeyDown(KeyCode.Space))
        {
           _ui.SetActive(true);
            Time.timeScale = 0;
        }
        #endregion
    }
    #region Upgrade Wall Medthod
    public void UpgradeWall()
    {
        if (_wallManager.CurrentWallUpgrade < _maxUpgrade)
        {
           _wallManager.CurrentWallUpgrade += 1;
           _wallManager.WallMaxPlace += 2;
        }
        else
        {
            Debug.Log("No more upgrade la juf");
        }
        _ui.SetActive(false);
        Time.timeScale = 1;
    }
    #endregion
    #region Upgrade Bullets Medthod
    public void UpgradeBullet()
    {
        if(_bulletSpawner._currentBulletUpgrade < _maxUpgradeForBullet)
        {
           _bulletSpawner._currentBulletUpgrade += 1;
            _bulletSpawner.speed += 0.3f;
            _bulletSpawner.firingRate -= 0.1f;
            _bulletSpawner.bulletLife -= 0.5f;
        }
        else
        {
            Debug.Log("No more upgrade la juf");
        }
        _ui.SetActive(false);
        Time.timeScale = 1;
    }
    #endregion
    #region Upgrade Electic Field Medthod
    public void UpgradeElecticField()
    {
        
        if(_eclecticFieldManager._currentEleticFieldUpgrade <= _maxUpgrade && _eclecticFieldSetTrue >= 1)
        {
            if (_eclecticFieldManager._currentEleticFieldUpgrade < _maxUpgrade)
            {
                _eclecticFieldManager._currentEleticFieldUpgrade += 1;
            }
            if (_eclecticFieldSetTrue > 1)
            {
                _eclecticFieldManager._previousIndex += 1;
            }
            _eclecticFieldSetTrue += 1;
            _eclecticFieldManager._electicField[_eclecticFieldManager._currentEleticFieldUpgrade].SetActive(true);
            
            
        }
        else if (_eclecticFieldManager._currentEleticFieldUpgrade == 0 && _eclecticFieldSetTrue == 0)
        {
            _eclecticFieldManager._electicField[0].SetActive(true);
            _eclecticFieldSetTrue += 1;
        }
        else
        {
            Debug.Log("No more upgrade la juf");
        }
        _ui.SetActive(false);
        Time.timeScale = 1;
    }
    #endregion
    #region Upgrade Turret Medthod
    public void UpgradeTurret()
    {

        if (_currentTurretUpgrade <= 5)
        {
            
            if (GameObject.FindWithTag("Turret") != null)
            {
                GameObject[] _existingTurret = GameObject.FindGameObjectsWithTag("Turret");
                foreach(GameObject _turret in _existingTurret)
                {
                    Destroy(_turret);
                }
               
            }
            GameObject _deployTurret = Instantiate(_turret[_currentTurretUpgrade], _turretSpawner.transform.position, Quaternion.identity);
            _currentTurretUpgrade += 1;
        }
        else
        {
            Debug.Log("No more upgrade la juf");
        }
        _ui.SetActive(false);
        Time.timeScale = 1;
    }

    #endregion
}
