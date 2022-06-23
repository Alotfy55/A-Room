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
        
        if (color_number == 0) // OFF-white
        {            
            ModelRenderer.material.SetColor("_Color", new Color(249f, 245f, 236f));
        }
        else if (color_number == 1) //biege
        {
            ModelRenderer.material.SetColor("_Color",new Color(174, 152, 130));
        }
        else if (color_number == 2) // brown
        {
            ModelRenderer.material.SetColor("_Color", new Color(128, 90, 64));
        }
        else if (color_number == 3) // blue
        {
            ModelRenderer.material.SetColor("_Color",new  Color(32,42,69));
        }
        else if (color_number == 4) // red
        {
            ModelRenderer.material.SetColor("_Color", new Color(126, 1, 22));
        }
        else if (color_number == 5) // black
        {
            ModelRenderer.material.SetColor("_Color", new Color(35, 31, 32));
        }
    }
}
