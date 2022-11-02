using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{

    Animator animator;
    public BottomBarManager bottomBarManager;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool clicked = false;

        foreach(Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began)
            {
                clicked = true;
                break;
            }
        }
        animator.SetBool("clcked", clicked && bottomBarManager.screenIndex == 2);
    }
}
