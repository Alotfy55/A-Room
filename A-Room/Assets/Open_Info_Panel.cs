using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Info_Panel : MonoBehaviour
{
    public GameObject info_panel;

    public void Open_panel()
    {
        this.transform.parent.gameObject.SetActive(false);
        info_panel.SetActive(true);
    }
}
