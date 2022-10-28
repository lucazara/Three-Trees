using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LymphManagerScript : MonoBehaviour
{
    public int lymph = 0;

    [SerializeField]
    private GameObject lymphLabel;

    [SerializeField]
    private GameObject treeManager;

    void Start()
    {
        lymph = PlayerPrefs.GetInt("lymph", 0);
        OnUpdateLymph();
    }

    public void AddLymph(int lymph_added)
    {
        lymph += lymph_added;
        OnUpdateLymph();
    }

    public bool Buy(int lymph_required)
    {
        if (lymph >= lymph_required)
        {
            lymph -= lymph_required;
            OnUpdateLymph();


            return true;
        }

        return false;
    }

    private void UpdateLymphLabel()
    {
        lymphLabel.GetComponent<Text>().text = lymph.ToString() + " lymph";
    }

    private void OnUpdateLymph()
    {
        PlayerPrefs.SetInt("lymph", lymph);
        UpdateLymphLabel();

        treeManager.GetComponent<TreeManagerScript>().UpdateVisibleUpagrades();
    }

}
