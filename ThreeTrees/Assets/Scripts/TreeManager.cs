using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeManager : MonoBehaviour
{
    public int lymph;
    public int lymph_per_click;
    public int selectedTreeType;


    private MyTree[][] allTrees;
    private MyTree[] trees;
    public GameObject[] tree_objects;


    [SerializeField] private GameObject forest;
    [SerializeField] private GameObject bottomBar;
    [SerializeField] private GameObject lymphLabel;


    public Sprite[] treeTypeSprites;

    private void OnUpdateLymph()
    {
        PlayerPrefs.SetInt("lymph", lymph);
        lymphLabel.GetComponent<Text>().text = lymph.ToString();
        UpdateVisibleUpgrades();
        UpdateCostUpgradeLabel();
    }




    void Start()
    {
        allTrees = new MyTree[4][];
        for (int i = 0; i < allTrees.Length; i++)
        {
            MyTree[] t = new MyTree[3];
            for (int j = 0; j < 3; j++)
            {
                t[j] = new MyTree(tree_objects[j], 3 * i + j);
               
            }

            allTrees[i] = t;
        }

        trees = new MyTree[3];
        UpdateSelectedTreeType();


        for (int i = 0; i < 3; i++)
            trees[i] = new MyTree(tree_objects[i], i);



        lymph = PlayerPrefs.GetInt("lymph", 0);
        OnUpdateLymph();
        CalculateLymphPerClick();
        UpdateCostUpgradeLabel();
        UpdateVisibleUpgrades();
        for (int i = 0; i < trees.Length; i++)
        {
            //Animator animator = tree_objects[i].GetComponent<Animator>();
            //animator.enabled = false;
        }



        //forest.GetComponent<Forest>().Start();
    }

    void Update()
    {
        if (bottomBar.GetComponent<BottomBarManager>().screenIndex == 2)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    lymph += lymph_per_click;
                    OnUpdateLymph();
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
        if (lymph >= tree.cost_upgrade)
        {
            lymph -= tree.cost_upgrade;
            OnUpdateLymph();

            tree.Upgrade();
            UpdateCostUpgradeLabel();
            CalculateLymphPerClick();
        }
        
    }


    public void UpdateSelectedTreeType()
    {
        selectedTreeType = forest.GetComponent<Forest>().treeSelectedIndex;

        for (int i = 0; i < 3; i++)
        {
            trees[i] = new MyTree(tree_objects[i], 3 * selectedTreeType + i);
            trees[i].tree_object.GetComponent<Image>().sprite = treeTypeSprites[selectedTreeType];
        }
        UpdateCostUpgradeLabel();
        UpdateVisibleUpgrades();
    }



    private void CalculateLymphPerClick()
    {
        lymph_per_click = 0;
        foreach (MyTree[] treeType in allTrees)
            foreach (MyTree tree in treeType)
                lymph_per_click += tree.lymph_per_click;

        
    }

    private void UpdateVisibleUpgrades()
    {
        foreach (MyTree tree in trees)
        {
            GameObject upgradeButton = tree.tree_object.transform.GetChild(2).gameObject;
            upgradeButton.SetActive(lymph >= tree.cost_upgrade);
        }
    }

    private void UpdateCostUpgradeLabel()
    {
        foreach (MyTree tree in trees)
        {
            GameObject label = tree.tree_object.transform.GetChild(3).gameObject;
            Text textLabel = label.GetComponent<Text>();

            textLabel.text = tree.cost_upgrade.ToString();
            textLabel.color = (lymph >= tree.cost_upgrade) ? Color.white : Color.red;

        }
    }
}