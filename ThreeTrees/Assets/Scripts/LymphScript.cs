using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LymphScript : MonoBehaviour
{

    private int lymph;
    private int lymph_per_click;

    private Text lymph_text;



    // Start is called before the first frame update
    void Start()
    {
        lymph = 0;
        lymph_per_click = 1;
        lymph_text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                lymph += lymph_per_click;
                lymph_text.text = lymph.ToString();
            }
        }
    }
}
