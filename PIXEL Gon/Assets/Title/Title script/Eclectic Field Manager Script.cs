using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EclecticFieldManagerScript : MonoBehaviour
{
    [SerializeField] public List<GameObject> _electicField;
    float _timer = 0f;
    float _lastFor = 5f;
    public int _currentEleticFieldUpgrade = 0;
    public int _previousIndex = 0;
    void Update()
    {
        if(_currentEleticFieldUpgrade > _previousIndex)
        {
            _electicField[_previousIndex].SetActive(false);
        }
        if (_electicField[_currentEleticFieldUpgrade].activeSelf)
        {
            _timer += Time.deltaTime;
            if( _timer >= _lastFor)
            {
                _electicField[_currentEleticFieldUpgrade].SetActive(false);
                StartCoroutine(WaitForSecond(10f));
            }
        }

    }
    IEnumerator WaitForSecond(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _timer = 0f;
        _electicField[_currentEleticFieldUpgrade].SetActive(true);
    }

}
