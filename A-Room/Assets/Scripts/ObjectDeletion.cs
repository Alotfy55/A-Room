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


    // Start is called before the first frame update
    void Start()
    {
        arCamera = GameObject.Find("AR Camera").GetComponent<Camera>();  // get the ar camera 
    }


    public GameObject panel;
    Transform parent;
    public void SwitchShowHide()
    {
        //parent = this.gameObject.GetComponent<RectTransform>();
        panel.transform.SetParent(parent.transform, true);
        panel.GetComponent<RectTransform>().localScale = new Vector2(0.001f, 0.001f);
        panel.transform.localPosition = new Vector3(0, 1, 0);
        panel.SetActive(true);
        Debug.Log("PANEL ACTIVATE");
    }
    // Update is called once per frame


    float ClickDuration = 1;
    bool clicking = false;
    float totalDownTime = 0;
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            totalDownTime = 0;
            clicking = true;
        }
        if (clicking && Input.GetMouseButton(0))
        {
            totalDownTime += Time.deltaTime;

            if (totalDownTime >= ClickDuration)
            {
                Debug.Log("Long click detected");
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
                                Debug.Log("Parent Found");
                                Debug.Log(parent.gameObject.name);
                                clicking = false;
                                SwitchShowHide();
                            }
                        }
                    }
                }
            }
        }
        if (clicking && Input.GetMouseButtonUp(0))
        {
            panel.SetActive(false);
        }
    }
}
