using System.Collections.Generic;
using System.Net;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class DamageSHOW : MonoBehaviour
{
    [SerializeField] private List<GameObject> _electicField;
    [SerializeField] private List<GameObject> _bullet;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _ui;
    int _currentBulletUpgrade = 0;
    int _currentEleticFieldUpgrade = 0;
    int _BeforeFieldIndex = -1;
    int _maxUpgrade = 2;
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 _mousePo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _mousePo.z = 0;

            Instantiate(_bullet[_currentBulletUpgrade], _mousePo, Quaternion.identity);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
           _ui.SetActive(true);
            Time.timeScale = 0;
        }
    }
    
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


    public void UpgradeElecticField()
    {
        if (_currentEleticFieldUpgrade <= _maxUpgrade)
        {
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
}
