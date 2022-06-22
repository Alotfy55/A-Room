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

    public GameObject[] furnitures;
    public Button removeAll;
    public int numOfFurniture = 0;


    public GameObject Menus;
    Transform parent_model;


    public void SwitchShowHide()
    {

        Menus.transform.parent = parent_model;
        Menus.transform.GetChild(0).gameObject.SetActive(true);
        Menus.transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector2(0.5f, 0.5f);


        //parent = this.gameObject.GetComponent<RectTransform>();
        //panel.transform.SetParent( canvas.transform, true);
        //panel.GetComponent<RectTransform>().localScale = new Vector2(0.01f, 0.01f);
        //update_option_panel_pos();
        //panel.SetActive(true);
        /*

             panel.transform.SetParent(parent.transform, false);
             panel.GetComponent<RectTransform>().localScale = new Vector2(0.001f, 0.001f);

             RectTransform CanvasRect = canvas.GetComponent<RectTransform>();


             Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(parent.transform.position);
             Vector2 WorldObject_ScreenPosition = new Vector2(
             ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
             ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));

             panel.GetComponent<RectTransform>().anchoredPosition = WorldObject_ScreenPosition;
             //panel.transform.localPosition = new Vector3(0, 1, 0);
             panel.SetActive(true);
             panel.GetComponent<RectTransform>().SetAsLastSibling();
        */

        /////////////yaraaabb/////////////////////
        //Update_pos();
        //panel.GetComponent<RectTransform>().localScale = new Vector2(0.5f, 0.5f);
        //panel.SetActive(true);  
      //  panel.GetComponent<RectTransform>().SetAsLastSibling();



    }

    /*void Update_pos()
    {
        Vector2 vec = Camera.main.WorldToScreenPoint(parent.transform.position);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRect, vec, null, out Vector2 localPoint);
        panel.transform.localPosition = localPoint;
    }*/

    public Transform getParent()
    {
        return parent_model;
    }

    // Start is called before the first frame update
    void Start()
    {
        arCamera = GameObject.Find("AR Camera").GetComponent<Camera>();  // get the ar camera 
    }

    
    public void removeFurniture()
    {
        
        furnitures = GameObject.FindGameObjectsWithTag("FurnitureModels");

        foreach (GameObject furniture in furnitures)
        {
            Destroy(furniture);
        }
        numOfFurniture = 0;
    }

        // Update is called once per frame
    void Update()
    {
        if (numOfFurniture == 0)
            removeAll.gameObject.SetActive(false);
        else
            removeAll.gameObject.SetActive(true);

        //if (parent != null)
        //    Update_pos();
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
                            parent_model = hit.collider.gameObject.transform;
                            SwitchShowHide();
                        }
                    }
                }
            }
        }
    }
}