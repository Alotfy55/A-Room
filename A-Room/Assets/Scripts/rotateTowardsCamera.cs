using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateTowardsCamera : MonoBehaviour
{
    Camera cam;
    private void Start()
    {
        cam = GameObject.Find("AR Camera").GetComponent<Camera>();
    }
    void Update()
    {
        transform.rotation = Quaternion.Lerp(this.transform.rotation, cam.transform.rotation, 10);
    }
}
