using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Info_Panel : MonoBehaviour
{
    public GameObject info_panel;
    Transform mymodel;

    public void Open_panel()
    {
        mymodel = this.transform.parent;
        mymodel = mymodel.transform.parent;


        info_panel.transform.SetParent(mymodel);  
        info_panel.SetActive(true);
    }
}
