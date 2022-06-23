using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close_option_panel : MonoBehaviour
{
    // Start is called before the first frame update
    public void close()
    {
        this.transform.parent.parent.gameObject.SetActive(false);
    }
}