using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeManagerScript : MonoBehaviour
{

    private MyTree[] trees;
    private int lymph_per_click;

    [SerializeField]
    private GameObject LymphManager;

    [SerializeField]
    private GameObject bottomBar;

    public GameObject[] tree_objects;

    void Start()
    {
        trees = new MyTree[3];
        for (int i = 0; i < 3; i++)
            trees[i] = new MyTree(tree_objects[i], i);

        CalculateLymphPerClick();
        UpdateCostUpgradeLabel();
        UpdateVisibleUpagrades();
    }

    void Update()
    {
        if (bottomBar.GetComponent<BottomBarManagerScript>().screenIndex == 2)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    LymphManager.GetComponent<LymphManagerScript>().AddLymph(lymph_per_click);
                }
            }
        }
        

        if (Input.GetKeyDown("c"))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("All player prefs cleared");
        }
    }

    public void UpgradeTree(int index)
    {
        MyTree tree = trees[index];
        if (LymphManager.GetComponent<LymphManagerScript>().Buy(tree.cost_upgrade))
        {
            tree.Upgrade();
            UpdateCostUpgradeLabel();
        }
    }

    private int CalculateLymphPerClick()
    {
        lymph_per_click = 0;
        foreach (MyTree tree in trees)
        {
            lymph_per_click += tree.lymph_per_click;
        }
        return lymph_per_click;
    }

    public void UpdateVisibleUpagrades()
    {
        foreach (MyTree tree in trees)
        {
            if (tree.cost_upgrade <= LymphManager.GetComponent<LymphManagerScript>().lymph)
            {
                tree.tree_object.transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                tree.tree_object.transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    public void UpdateCostUpgradeLabel()
    {
        foreach (MyTree tree in trees)
        {
            GameObject label = tree.tree_object.transform.GetChild(3).gameObject;
            label.GetComponent<Text>().text = "up: " + tree.cost_upgrade.ToString();
        }
    }

}
