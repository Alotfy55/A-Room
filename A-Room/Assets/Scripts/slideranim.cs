using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideranim : MonoBehaviour
{
    public GameObject PanelMenu;
    RectTransform rt;
    public float easing = 0.5f;
    bool opened = true;
    public void ShowhHideMenu()
    {
        rt = GetComponent<RectTransform>();
        
        if (opened)
        {
            //transform.position += new Vector3(0, 500, 0);
            StartCoroutine(SmoothMove(rt.sizeDelta,1700, easing));
           // rt.sizeDelta = new Vector2(rt.sizeDelta.x, 1700);
            opened = false;
        }
        else
        {
           // rt.sizeDelta = new Vector2(rt.sizeDelta.x, 0);
            StartCoroutine(SmoothMove(rt.sizeDelta, 0, easing));
            opened = true;
        }



        //if (PanelMenu != null)
        //{
        //    Animator animator = PanelMenu.GetComponent<Animator>();
        //    if (animator != null)
        //    {
        //        bool isopen = animator.GetBool("show");
        //        animator.SetBool("show", !isopen);

        //    }
        //}

    }
    IEnumerator SmoothMove(Vector2 startpos, int hight, float seconds)
    {
        float t = 0f;
        Vector2 endpos = rt.sizeDelta;
       
        
       
            endpos.y = hight;
        
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            rt.sizeDelta =  Vector2.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }
}
