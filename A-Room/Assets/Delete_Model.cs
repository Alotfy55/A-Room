using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_Model : MonoBehaviour
{
    Transform obj;

    public void Delete_GameObj()
    {
        obj = this.transform.parent;
        //Debug.Log("Destroy Parent and child");
        Destroy(obj.transform.parent.gameObject);
        this.transform.parent.gameObject.SetActive(false);

    }
}
