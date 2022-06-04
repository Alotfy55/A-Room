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

        panel.GetComponent<RectTransform>().localScale = new Vector2(0.01f, 0.01f);
        update_option_panel_pos();
        panel.SetActive(true);


        //panel.GetComponent<RectTransform>().localScale = new Vector2(0.001f, 0.001f);
        //update_option_panel_pos();
        //parent.GetChild(0).gameObject.GetComponent<Canvas>().worldCamera = arCamera;
        //parent.GetChild(0).GetChild(0).gameObject.SetActive(true);
        //panel.gameObject.SetActive(true);

        //panel.GetComponent<RectTransform>().SetAsLastSibling();
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



    // Update is called once per frame
    void Update()
    {
        if (parent != null)
        {
            update_option_panel_pos();
        }

        if (Input.touchCount == 2)   // touch occured
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
    void update_option_panel_pos()
    {

        Vector2 screenPos = Camera.main.WorldToScreenPoint(parent.gameObject.GetComponent<RectTransform>().position);
        float scaleFactor = GameObject.Find("Canvas").GetComponent<Canvas>().scaleFactor;
        screenPos = new Vector2(screenPos.x / scaleFactor, screenPos.y / scaleFactor);
        panel.GetComponent<RectTransform>().anchoredPosition = screenPos;

        //panel.transform.parent.transform.position = new Vector3(parent.position.x, parent.localScale.y + 5, parent.position.z);
        //Vector3 screenPos = Camera.main.WorldToScreenPoint(parent.position);
        //panel.transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector3(screenPos.x,screenPos.y,0);
        //panel.GetComponent<RectTransform>().SetAsLastSibling();
    }
}
