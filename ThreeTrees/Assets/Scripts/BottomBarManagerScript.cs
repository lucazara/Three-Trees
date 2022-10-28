using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomBarManagerScript : MonoBehaviour
{
    public int screenIndex;

    void Start()
    {
       screenIndex = 2;
    }

    public void ToHome()
    {
        screenIndex = 2;

    }

    public void ToUpgrades()
    {
        screenIndex = 3;


    }
}
