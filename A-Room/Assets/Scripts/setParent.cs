using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setParent : MonoBehaviour
{
    public GameObject Menus;
    public Transform parent_model;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SwitchShowHide()
    {

        Menus.transform.parent = parent_model;
        Menus.transform.GetChild(0).gameObject.SetActive(true);
        //Menus.transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector2(0.5f, 0.5f);
        Menus.transform.localPosition = new Vector3(0f, 1f,0f);


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
