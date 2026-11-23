using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RNGUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject[] _allUpgradePossible; //4
    [SerializeField] private Transform[] _appearPosition; // 3
   
    private void OnEnable()
    {
        foreach (GameObject upgradePossible in _allUpgradePossible)
        {
            upgradePossible.SetActive(false);
        }
        RandomPickUpgrade();
    }
    private void RandomPickUpgrade()
    {
        List<int> _availableUpgrades = new List<int>(); //list of 4 int
        for (int i = 0; i < _allUpgradePossible.Length; i++)
        {
            _availableUpgrades.Add(i); 
        }
        for(int i = 0; i < 3; i++)
        {
            int _randomIndex = Random.Range(0, _availableUpgrades.Count); //0 1 2 3  if get 0
            int _selectedUpgradeIndex = _availableUpgrades[_randomIndex];
            GameObject _selectedUpgrade = _allUpgradePossible[_selectedUpgradeIndex];
            _availableUpgrades.RemoveAt(_randomIndex); // 1 2 3
            SetPositionForSelectedUpgrade(_selectedUpgrade, i);
        }
    }
    private void SetPositionForSelectedUpgrade(GameObject selectedUpgrade,int position)
    {
        selectedUpgrade.transform.position = _appearPosition[position].position;
        selectedUpgrade.SetActive(true);
    }
}
