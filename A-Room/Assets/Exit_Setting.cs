using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Setting : MonoBehaviour
{
    // Start is called before the first frame update
    public void exit_panel()
    {
        this.transform.parent.gameObject.SetActive(false);
    }
}
