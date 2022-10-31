using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomBarManager : MonoBehaviour
{
    public int screenIndex;
    public GameObject home;

    void Start()
    {
       screenIndex = 2;
    }

    public void ToHome()
    {
        screenIndex = 2;
        home.SetActive(true);

    }

    public void ToUpgrades()
    {
        screenIndex = 3;
        home.SetActive(false);
    }
}
