using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Forest : MonoBehaviour
{
    GameObject panel;
    GameObject target;
    int targetIndex;

    public int treeSelectedIndex;

    public float rate = 0.1f;
    public bool lerping = true;


    public GameObject treeManager;



    private void Start()
    {
        panel = transform.GetChild(0).GetChild(0).gameObject;
        target = panel.transform.GetChild(0).gameObject;
        targetIndex = 0;
        treeSelectedIndex = 0;
    }

    private void Update()
    {
        if (lerping)
        {
            Vector2 targetPosition = -target.GetComponent<RectTransform>().anchoredPosition;
            Vector2 currentPosition = panel.GetComponent<RectTransform>().anchoredPosition;
            panel.GetComponent<RectTransform>().anchoredPosition += (targetPosition - currentPosition) * rate;
            if (Vector2.Distance(currentPosition, targetPosition) < 10)
            {
                lerping = false;
            }

        }

        for (int i = 0; i < panel.transform.childCount; i++)
        {
            GameObject tree = panel.transform.GetChild(i).gameObject;
            tree.GetComponent<Image>().color = (i == targetIndex) ? Color.yellow : Color.white;
        }
    }

    public void TouchedTree(int index)
    {
        targetIndex = index;
        treeSelectedIndex = index;
        target = panel.transform.GetChild(index).gameObject;
        lerping = true;

        treeManager.GetComponent<TreeManager>().UpdateSelectedTreeType();
    }

    public void TouchedBackground()
    {
        lerping = false;
        targetIndex = -1;
    }
}