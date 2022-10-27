using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LymphManagerScript : MonoBehaviour
{
    public int lymph = 0;

    [SerializeField]
    private GameObject lymphLabel;

    void Start()
    {
        lymph = PlayerPrefs.GetInt("lymph", 0);
        UpdateLymphLabel();
    }

    public void AddLymph(int lymph_added)
    {
        lymph += lymph_added;
        PlayerPrefs.SetInt("lymph", lymph);
        UpdateLymphLabel();
    }

    public bool Buy(int lymph_required)
    {
        if (lymph >= lymph_required)
        {
            lymph -= lymph_required;
            PlayerPrefs.SetInt("lymph", lymph);
            UpdateLymphLabel();

            return true;
        }

        return false;
    }

    private void UpdateLymphLabel()
    {
        lymphLabel.GetComponent<Text>().text = lymph.ToString() + " lymph";
    }
}
