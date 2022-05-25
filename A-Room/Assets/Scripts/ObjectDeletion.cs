using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ObjectDeletion : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager arRaycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    Camera arCamera;

    public GameObject panel;
    Transform parent;
    public void SwitchShowHide()
    {
        //parent = this.gameObject.GetComponent<RectTransform>();
        panel.transform.SetParent(parent.transform, true);
        panel.GetComponent<RectTransform>().localScale = new Vector2(0.001f, 0.001f);
        panel.transform.localPosition = new Vector3(0, 1, 0);
        panel.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        arCamera = GameObject.Find("AR Camera").GetComponent<Camera>();  // get the ar camera 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 3)   // touch occured
        {
            if (arRaycastManager.Raycast(Input.GetTouch(0).position, hits)) // whether touch hits a detected plane plane
            {
                if (Input.GetTouch(0).phase == TouchPhase.Stationary) // If a hold occured
                {
                    RaycastHit hit;
                    Ray ray = arCamera.ScreenPointToRay(Input.GetTouch(0).position);

                    if (Physics.Raycast(ray, out hit)) // cast a ray from ray to screen 
                    {
                        if (hit.collider.gameObject.tag.Equals("FurnitureModels")) // if the ray collides with an object whose tag "FurnitureModels"
                        {
                            parent = hit.collider.gameObject.transform;
                            SwitchShowHide();
                        }
                    }
                }
            }
        }
    }
}