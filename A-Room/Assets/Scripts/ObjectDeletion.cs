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
        Menus.transform.gameObject.SetActive(true);
        Menus.transform.localPosition = new Vector3(0f, parent_model.GetComponent<Renderer>().bounds.size.y + 0.3f, 0f);

    }
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