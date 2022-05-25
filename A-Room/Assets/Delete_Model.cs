using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_Model : MonoBehaviour
{

    Transform model;
    public void Delete_GameObj()
    {
        model = FindObjectOfType<ObjectDeletion>().getParent();
        Destroy(model.gameObject);  
        this.transform.parent.gameObject.SetActive(false);
    }
}
