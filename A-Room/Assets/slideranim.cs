using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideranim : MonoBehaviour
{
    public GameObject PanelMenu;

    public void ShowhHideMenu()
    {

        if (PanelMenu != null)
        {
            Animator animator = PanelMenu.GetComponent<Animator>();
            if (animator != null)
            {
                bool isopen = animator.GetBool("show");
                animator.SetBool("show", !isopen);

            }
        }

    }
}
