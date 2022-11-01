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
        animator.SetBool("clcked", Input.touchCount > 0 && bottomBarManager.screenIndex == 2);
    }
}
