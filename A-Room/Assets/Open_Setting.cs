using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Setting : MonoBehaviour
{
    public GameObject setting_panel;

    [System.Obsolete]
    public void open_setting_panel()
    {
        if (setting_panel.active == false)
            setting_panel.SetActive(true);
        else
            setting_panel.SetActive(false);                 
    } 
}
