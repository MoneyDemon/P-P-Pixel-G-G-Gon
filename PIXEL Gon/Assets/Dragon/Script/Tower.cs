using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public float _towerHealth = 100;


    private void Update()
    {
        if(_towerHealth <= 0)
        {
            Debug.Log("GGsEz");
        }
    }

   
}
