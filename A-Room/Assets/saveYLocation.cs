using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveYLocation : MonoBehaviour
{
    // Start is called before the first frame update
    private float yPos;
    void Start()
    {
        yPos = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x,yPos , transform.position.z);
    }
}
