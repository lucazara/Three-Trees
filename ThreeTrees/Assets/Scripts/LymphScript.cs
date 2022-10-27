using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LymphScript : MonoBehaviour
{

    private int lymph = 0;
    private int lymph_per_click;

    private Text lymph_text;


    void Start()
    {
        lymph_text = GetComponent<Text>();

        lymph = PlayerPrefs.GetInt("lymph", 0);
        lymph_per_click = PlayerPrefs.GetInt("lymph_per_click", 1);

        lymph_text.text = lymph.ToString() + " lymph";
    }

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                produceLymph();
                lymph_text.text = lymph.ToString() + " lymph";
            }
        }

        if (Input.GetKeyDown("c"))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("player prefs cleared");
        }
    }


    void produceLymph()
    {
        lymph += lymph_per_click;
        PlayerPrefs.SetInt("lymph", lymph);
    }
}
