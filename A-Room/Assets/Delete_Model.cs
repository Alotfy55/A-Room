using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_Model : MonoBehaviour
{

    Transform model;
    public void Delete_GameObj()
    {
        var obj = FindObjectOfType<ObjectDeletion>();
        obj.numOfFurniture--;
        model = obj.getParent();
        Destroy(model.gameObject);  
        this.transform.parent.gameObject.SetActive(false);
    }
}
