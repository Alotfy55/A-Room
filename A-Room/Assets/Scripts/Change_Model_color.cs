using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Change_Model_color : MonoBehaviour
{
    public int color_number;
    GameObject model;
    public GameObject border;

    public void change_color()
    {
        model = FindObjectOfType<ObjectDeletion>().getParent().gameObject;
        var ModelRenderer = model.GetComponent<Renderer>();
        border.SetActive(true);
        border.transform.localPosition = this.transform.localPosition;

        Color clr = new Color(0, 0, 0);
        if (color_number == 0) // OFF-white
        {
            clr = new Color(249f / 255, 245f / 255, 236f / 255);
        }
        else if (color_number == 1) //biege
        {
            clr = new Color(174f / 255, 152f / 255, 130f / 255);
        }
        else if (color_number == 2) // brown
        {
            clr = new Color(128f / 255, 90f / 255, 64f / 255);
        }
        else if (color_number == 3) // blue
        {
            clr = new Color(32 / 255f, 42 / 255f, 69 / 255f);
        }
        else if (color_number == 4) // red
        {
            clr = new Color(126 / 255f, 1 / 255f, 22 / 255f);
        }
        else if (color_number == 5) // black
        {
            clr = new Color(35 / 255f, 31 / 255f, 32 / 255f);
        }
        ModelRenderer.material.color = clr;
    }
}
