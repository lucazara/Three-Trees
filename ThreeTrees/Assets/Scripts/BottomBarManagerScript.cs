using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomBarManagerScript : MonoBehaviour
{

    public GameObject plants;
    public GameObject upgrades;

    private int screenIndex;

    void Start()
    {
        screenIndex = 2;
    }

    void Update()
    {

    }

    public void ToHome()
    {
        screenIndex = 2;
        upgrades.SetActive(false);
        plants.SetActive(true);
    }

    public void ToUpgrades()
    {
        screenIndex = 3;
        upgrades.SetActive(true);
        plants.SetActive(false);
    }
}
