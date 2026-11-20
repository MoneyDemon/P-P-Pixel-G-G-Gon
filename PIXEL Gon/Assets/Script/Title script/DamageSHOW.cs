using TMPro.EditorUtilities;
using UnityEngine;

public class DamageSHOW : MonoBehaviour
{
   
    int _BaseDamage = 20;
    int _currentDamage => _BaseDamage;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(_currentDamage);
        }
        if (Input.GetKey(KeyCode.I))
        {
            IncDam(_currentDamage);
            Debug.Log("Upgraded");
        }
    }
    public void IncDam(int damage)
    {
        damage = damage + 1;
    }
}
