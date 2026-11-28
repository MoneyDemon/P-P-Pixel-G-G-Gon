using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _wall;
    [SerializeField] private List<GameObject> _wallPreview;
    [SerializeField] private TMP_Text _displayWallCurrentCount;
    #region About Wall
    public int CurrentWallUpgrade = 0;
    int _wallCounting = 0;
    public int WallMaxPlace = 5;
    float _wallCD = 15;
    float _rotation = 0;
    private void Start()
    {
        _wallCounting = WallMaxPlace;
    }
    #endregion
    void Update()
    {
        if (_wallCounting > 0)
        {
            _displayWallCurrentCount.text = _wallCounting.ToString();
        }
        #region Preview wall
        Vector3 _mousePo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePo.z = 0;
        if( _wallCounting > 0 && Time.timeScale != 0)
        {
            if (_wallPreview[CurrentWallUpgrade].activeSelf != true)
            {
                _wallPreview[CurrentWallUpgrade].SetActive(true);
                if (CurrentWallUpgrade == 1 || CurrentWallUpgrade == 2 && _wallPreview[CurrentWallUpgrade - 1].activeSelf == true)
                {
                    _wallPreview[CurrentWallUpgrade - 1].SetActive(false);
                }
            }
           
            _wallPreview[CurrentWallUpgrade].transform.position = _mousePo;
            _wallPreview[CurrentWallUpgrade].transform.rotation = Quaternion.Euler(0, 0, _rotation);
        }
        #endregion
        #region M1 to spawn Wall
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0 && _wallCounting > 0)
        {

            Instantiate(_wall[CurrentWallUpgrade], _mousePo, Quaternion.Euler(0f, 0f, _rotation));
            _wallCounting -= 1;
            if (_wallCounting == 0)
            {
                _displayWallCurrentCount.text = "Wall On CD";
                StartCoroutine(WaitForSecond(_wallCD));
            }
        }
        #endregion
        #region Rotate wall
        if (Input.GetKeyDown(KeyCode.R))
        {
            _rotation += 45;
        }
        #endregion

    }
    #region Wait IENU
    IEnumerator WaitForSecond(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _wallCounting = WallMaxPlace;
    }
    #endregion
}
