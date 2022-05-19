using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Model_color : MonoBehaviour
{
    public int color_number;
    GameObject model;

    public void change_color()
    {
        model = this.transform.parent.gameObject;
        model = model.transform.parent.gameObject;
        var ModelRenderer = model.GetComponent<Renderer>();

        Debug.Log(model.name);
        if (color_number == 0) // red
        {
            ModelRenderer.material.SetColor("_Color", Color.red);
        }
        else if (color_number == 1) //green
        {
            ModelRenderer.material.SetColor("_Color", Color.green);
        }
        else if (color_number == 2) // blue
        {
            ModelRenderer.material.SetColor("_Color", Color.blue);
        }
        else if (color_number == 3) // black
        {
            ModelRenderer.material.SetColor("_Color", Color.black);
        }
        else if (color_number == 4) // white
        {
            ModelRenderer.material.SetColor("_Color", Color.white);
        }
        
    }
}
