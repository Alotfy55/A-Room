using System.Collections;
using System.Collections.Generic;
using Lean.Common;
using Lean.Touch;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class SpawnableObject : MonoBehaviour
{
    [SerializeField] ARRaycastManager arRaycastManager;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    [SerializeField] GameObject spawnablePrefab;

    [SerializeField] private Text debuggingValue;
    Camera arCamera;
    GameObject []spawnableObject;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnableObject = new GameObject[1];
        //arCamera = GameObject.Find("AR Camera").GetComponent<Camera>();  // get the ar camera 
        addLeanComponents(spawnablePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) // touch occured
        {
            if (arRaycastManager.Raycast(Input.GetTouch(0).position, hits)) // whether touch hits a detected plane plane
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began &&
                    spawnableObject[counter] == null) // check for a touch and no object have been instantiate before 
                {
                    SpawnPrefab(hits[0].pose.position); // Instantiate an object in the ar scene
                }
                /*
                else if (Input.GetTouch(0).phase == TouchPhase.Moved && spawnableObject != null)
                {
                    spawnableObject.transform.position = hits[0].pose.position; 
                }
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    //spawnableObject = null; 
                }
                */
            }
        }
    }

    private void SpawnPrefab(Vector3 spawnPos)
    {
        spawnableObject[counter++] = Instantiate(spawnablePrefab, spawnPos, Quaternion.identity);
    }

    private void addLeanComponents(GameObject prefab)
    {
        prefab.AddComponent<LeanSelectable>();
        prefab.AddComponent<LeanSelectableByFinger>();
        prefab.AddComponent<LeanDragTranslate>();
        prefab.GetComponent<LeanDragTranslate>().Use.RequiredFingerCount = 1;
        prefab.GetComponent<LeanDragTranslate>().Camera = GameObject.Find("AR Camera").GetComponent<Camera>();
        prefab.GetComponent<LeanDragTranslate>().Sensitivity = 2;
        prefab.AddComponent<LeanTwistRotateAxis>();
        prefab.AddComponent<saveYLocation>();

        debuggingValue.text = "components added";
    }

}