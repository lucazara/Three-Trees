using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomBarManager : MonoBehaviour
{
    public int screenIndex;

    public GameObject home;
    public GameObject upgrades;

    void Start()
    {
        screenIndex = 2;
    }



    public void ToSettings()
    {
        screenIndex = 0;
        home.SetActive(false);
        upgrades.SetActive(false);
    }

    public void ToForest()
    {
        screenIndex = 1;
        home.SetActive(false);
        upgrades.SetActive(false);
    }

    public void ToHome()
    {
        screenIndex = 2;
        home.SetActive(true);
        upgrades.SetActive(false);
    }

    public void ToUpgrades()
    {
        screenIndex = 3;
        home.SetActive(false);
        upgrades.SetActive(true);
    }

    public void ToShop()
    {
        screenIndex = 4;
        home.SetActive(false);
        upgrades.SetActive(false); 
    }
}
