using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateTowardsCamera : MonoBehaviour
{
    // Start is called before the first frame update
    Camera cam;
    private void Start()
    {
        cam = GameObject.Find("AR Camera").GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Lerp(this.transform.rotation, cam.transform.rotation, 10);
    }
}
