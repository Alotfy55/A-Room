using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Open_Info_Panel : MonoBehaviour
{
    public GameObject info_panel;
    GameObject l;
    GameObject w;
    GameObject h;


    public void Open_panel()
    {

        this.transform.parent.parent.gameObject.SetActive(false);
        info_panel.SetActive(true);

        l = info_panel.transform.GetChild(7).gameObject;
        w = info_panel.transform.GetChild(8).gameObject;
        h = info_panel.transform.GetChild(9).gameObject;

        l.GetComponent<Text>().text += FindObjectOfType<ObjectDeletion>().getParent().transform.localScale.x;
        w.GetComponent<Text>().text += FindObjectOfType<ObjectDeletion>().getParent().transform.localScale.z;
        h.GetComponent<Text>().text += FindObjectOfType<ObjectDeletion>().getParent().transform.localScale.y;

    }
}
