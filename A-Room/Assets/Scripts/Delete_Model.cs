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
        model.transform.GetChild(0).gameObject.SetActive(false);
        model.transform.GetChild(0).parent = null;
        Destroy(model.gameObject);  
    }
}
