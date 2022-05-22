using System.Collections;
using System.Collections.Generic;
using Lean.Common;
using Lean.Touch;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnableObject : MonoBehaviour
{
    [SerializeField] ARRaycastManager arRaycastManager;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public GameObject spawnablePrefab;

    [SerializeField] private Text debuggingValue;
    GameObject spawnableObject;
    
    public bool picked;

    // Start is called before the first frame update
    void Start()
    {
        picked = false;
        spawnableObject = null;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) // touch occured
        {
            if (arRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon) && picked) // whether touch hits a detected plane plane
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began) // check for a touch and no object have been instantiate before 
                {
                    addLeanComponents(spawnablePrefab); // Add components to current prefab.
                    SpawnPrefab(hits[0].pose.position); // Instantiate an object in the ar scene
                    picked = false;
                }
            }
        }
    }

    private void SpawnPrefab(Vector3 spawnPos)
    {
        spawnableObject = Instantiate(spawnablePrefab, spawnPos, Quaternion.identity);
    }

    private void addLeanComponents(GameObject prefab)
    {
        prefab.AddComponent<LeanSelectableOutline>();
        prefab.AddComponent<LeanSelectableByFinger>();
        prefab.AddComponent<LeanDragTranslate>();
        prefab.GetComponent<LeanDragTranslate>().Use.RequiredFingerCount = 1;
        prefab.GetComponent<LeanDragTranslate>().Camera = GameObject.Find("AR Camera").GetComponent<Camera>();
        prefab.GetComponent<LeanDragTranslate>().Sensitivity = 2;
        prefab.AddComponent<LeanTwistRotateAxis>();
        prefab.GetComponent<LeanTwistRotateAxis>().Sensitivity = 2;
        prefab.AddComponent<saveYLocation>();
        prefab.AddComponent<BoxCollider>();
        prefab.AddComponent<Rigidbody>();
        prefab.GetComponent<Rigidbody>().useGravity = false;
        prefab.GetComponent<Rigidbody>().drag = float.MaxValue;
        prefab.GetComponent<Rigidbody>().angularDrag = float.MaxValue;
        prefab.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
        prefab.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;


        var outline = prefab.AddComponent<Outline1>();

        outline.OutlineMode = Outline1.Mode.OutlineVisible;
        outline.OutlineColor = Color.cyan;
        outline.OutlineColor2 = Color.red;
        outline.OutlineWidth = 5f;
        outline.enabled = false;

        prefab.tag = "FurnitureModels";

        debuggingValue.text = "components added";
    }

}