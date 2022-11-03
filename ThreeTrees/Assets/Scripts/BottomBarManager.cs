using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomBarManager : MonoBehaviour
{
    public int screenIndex;

    public GameObject home;
    public GameObject upgrades;
    public GameObject settings;
    public GameObject forest;

    void Start()
    {
        ToHome();
    }



    public void ToSettings()
    {
        screenIndex = 0;
        settings.SetActive(true);
        home.SetActive(false);
        upgrades.SetActive(false);
        forest.SetActive(false);
    }

    public void ToForest()
    {
        screenIndex = 1;
        settings.SetActive(false);
        home.SetActive(false);
        upgrades.SetActive(false);
        forest.SetActive(true);


    }

    public void ToHome()
    {
        screenIndex = 2;
        settings.SetActive(false);
        home.SetActive(true);
        upgrades.SetActive(false);
        forest.SetActive(false);

    }

    public void ToUpgrades()
    {
        screenIndex = 3;
        settings.SetActive(false);
        home.SetActive(false);
        upgrades.SetActive(true);
        forest.SetActive(false);

    }

    public void ToShop()
    {
        screenIndex = 4;
        settings.SetActive(false);
        home.SetActive(false);
        upgrades.SetActive(false);
        forest.SetActive(false);

    }
}
