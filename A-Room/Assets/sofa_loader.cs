using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sofa_loader : MonoBehaviour
{
    public GameObject b;
    public Transform panel;

    public void Create()
    {
        GameObject a = (GameObject)Instantiate(b);
        a.transform.SetParent(panel.transform);
    }
}
