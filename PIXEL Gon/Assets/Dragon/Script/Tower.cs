using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public float _towerHealth = 100;
    
    [SerializeField]  Slider _healthSlider;
    [SerializeField] TMP_Text _healthText;

    private void Update()
    {
        _healthSlider.value = _towerHealth/100;
        _healthText.text = Mathf.CeilToInt(_towerHealth).ToString();
        if(_towerHealth <= 0)
        {
            Debug.Log("GGsEz");
            Destroy(gameObject);
        }
    }

   
}
