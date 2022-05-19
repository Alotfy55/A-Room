using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Info_Panel : MonoBehaviour
{
    Transform obj;

    public void Exit_Panel()
    {
        obj = this.transform.parent;
        obj.gameObject.SetActive(false);
    }
}
