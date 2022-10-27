using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTree
{

    public int lymph_per_click;
    public int cost_upgrade;

    public int level;

    public MyTree()
    {
        level = 1;
        lymph_per_click = 1;
        cost_upgrade = 10;
    }

    public void Upgrade()
    {
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


        level++;
    }
}
