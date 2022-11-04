using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyTree
{

    public int lymph_per_click;
    public int cost_upgrade;
    public GameObject tree_object;
    public GameObject forest;
    public int id;
    public int typeIndex;

    public int level;

    public MyTree(GameObject t, int id)
    {
        level = PlayerPrefs.GetInt("tree " + id.ToString() + " level", 1);
        lymph_per_click = PlayerPrefs.GetInt("tree " + id.ToString() + " lymph_per_click", 1);
        cost_upgrade = PlayerPrefs.GetInt("tree " + id.ToString() + " cost_upgrade", 50);
        tree_object = t;
        this.id = id;

        typeIndex = (id - (id % 3)) / 3;

        tree_object.transform.GetChild(0).GetComponent<Text>().text = "+     " + lymph_per_click.ToString();
        tree_object.transform.GetChild(1).GetComponent<Text>().text = "level " + level.ToString();

    }

    public void Upgrade() 
    {
        //TODO: USE TYPEINDEX TO CHANGE LYMPH PER CLICK AND COSTS
        if (level < 10)
        {
            lymph_per_click += level;
        }
        else if (level < 20)
        {
            lymph_per_click += 2 * level;
        }
        else
        {
            lymph_per_click += 3 * level;
        }

        cost_upgrade *= 2;

        level++;

        PlayerPrefs.SetInt("tree " + id.ToString() + " level", level);
        PlayerPrefs.SetInt("tree " + id.ToString() + " cost_upgrade", cost_upgrade);
        PlayerPrefs.SetInt("tree " + id.ToString() + " lymph_per_click", lymph_per_click);

        tree_object.transform.GetChild(0).GetComponent<Text>().text = "+     " + lymph_per_click.ToString();
        tree_object.transform.GetChild(1).GetComponent<Text>().text = "level " + level.ToString();


    }
}
