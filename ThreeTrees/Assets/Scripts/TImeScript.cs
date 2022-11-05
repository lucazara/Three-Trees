using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class TImeScript : MonoBehaviour
{

    [SerializeField] GameObject sun;
    [SerializeField] GameObject moon;


    public PostProcessProfile profile;

    void Update()
    {
        int hours = System.DateTime.Now.Hour;
        GetComponent<Text>().text = System.DateTime.Now.ToString("hh:mm");

        if (hours >= 6 && hours <= 18)
        {
            sun.SetActive(true);
            moon.SetActive(false);
            ColorParameter c = new();
            c.value = Color.yellow;
            profile.GetSetting<Bloom>().color = c;
        }
        else
        {
            sun.SetActive(false);
            moon.SetActive(true);
            ColorParameter c = new();
            c.value = Color.blue;
            profile.GetSetting<Bloom>().color = c;
        }
    }
}
