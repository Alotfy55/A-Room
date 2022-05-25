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
        //panel.transform.SetParent( canvas.transform, true);
        //panel.GetComponent<RectTransform>().localScale = new Vector2(0.001f, 0.001f);
        //panel.transform.localPosition = new Vector3(0, 1, 0);
        panel.SetActive(true);
        panel.GetComponent<RectTransform>().SetAsLastSibling();
    }

    public Transform getParent()
    {
        return parent;
    }

    // Start is called before the first frame update
    void Start()
    {
        arCamera = GameObject.Find("AR Camera").GetComponent<Camera>();  // get the ar camera 
    }


    private float timePressed = 0.0f;
    private float timeLastPress = 0.0f;
    public float timeDelayThreshold = 1.0f;
    void Update()
    {
        

    void Update()
    {
        checkForLongPress(timeDelayThreshold);
    }

    void checkForLongPress(float tim)
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        { // If the user puts her finger on screen...
            timePressed = Time.time - timeLastPress;
        }

        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        { // If the user raises her finger from screen
            timeLastPress = Time.time;
            if (timePressed > tim)
            { // Is the time pressed greater than our time delay threshold?
                Updatee();
            }
        }
    }

}
    // Update is called once per frame
    void Updatee()
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