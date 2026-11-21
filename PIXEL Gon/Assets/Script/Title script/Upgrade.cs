using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class DamageSHOW : MonoBehaviour
{
    #region get Game object ref
    [SerializeField] private List<GameObject> _electicField;
    [SerializeField] private List<GameObject> _bullet;
    [SerializeField] private List<GameObject> _wall;
    [SerializeField] private List<GameObject> _turret;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _ui;
    [SerializeField] private GameObject _turretSpawner;
    #endregion
    int _currentBulletUpgrade = 0;
    int _currentTurretUpgrade = 0;
    #region About Wall
    int _currentWallUpgrade = 0;
    int _wallCounting = 0;
    int _wallMaxPlace = 5;
    float _wallCD = 15;
    int _isCDchecking = 1;
    float _rotation = 0;
    #endregion
    int _currentEleticFieldUpgrade = 0;
    int _maxUpgrade = 2;

    void Update()
    {
        #region M1 to spawn bullets & M2 to spawn Wall
        if (Input.GetMouseButtonDown(1) && Time.timeScale != 0)
        {
            Vector3 _mousePo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _mousePo.z = 0;

            Instantiate(_bullet[_currentBulletUpgrade], _mousePo, Quaternion.identity);
        }
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0 && _wallCounting < _wallMaxPlace * ( _isCDchecking * (_currentWallUpgrade + 1)))
        {
            Vector3 _mousePo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _mousePo.z = 0;

            Instantiate(_wall[_currentWallUpgrade], _mousePo, Quaternion.Euler(0f, 0f, _rotation)) ;
            _wallCounting += 1;
            if(_wallCounting == _wallMaxPlace)
            {
                _isCDchecking = 0;
                Debug.Log("CD ON");
                StartCoroutine(WaitForSecond(_wallCD)); 
            }
        }
        #endregion
        #region Rotate wall
        if (Input.GetKeyDown(KeyCode.R))
        {
            _rotation += 45;
            Debug.Log($"Current wall rotation: {_rotation % 180}");
        }
        #endregion
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
        if (_currentWallUpgrade < _maxUpgrade)
        {
            _currentWallUpgrade += 1;
            _wallMaxPlace += 5;
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
        if(_currentBulletUpgrade < _maxUpgrade)
        {
           _currentBulletUpgrade += 1;
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
        if (_currentEleticFieldUpgrade <= _maxUpgrade)
        {
            GameObject _existingField = null;
            if (GameObject.FindWithTag("Field") != null)
            {
                _existingField = GameObject.FindWithTag("Field");
                Destroy(_existingField);
            }
            GameObject _fieldAct = Instantiate(_electicField[_currentEleticFieldUpgrade], _player.transform.position, Quaternion.identity);
            _fieldAct.transform.SetParent(_player.transform);
            _currentEleticFieldUpgrade += 1;
        }
        else
        {
            Debug.Log("No more upgrade la juf");
        }
        _ui.SetActive(false);
        Time.timeScale = 1;
    }
    #endregion
    #region Wait IENU
    IEnumerator WaitForSecond(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _isCDchecking = 1;
        Debug.Log("CD OFF");
        _wallCounting = 0;
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
