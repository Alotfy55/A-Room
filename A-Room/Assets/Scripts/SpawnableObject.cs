using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lean.Common;
using Lean.Touch;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnableObject : MonoBehaviour
{
    [SerializeField] ARRaycastManager arRaycastManager;

    

    public GameObject spawnablePrefab;
    public GameObject placementIndicator;

    [SerializeField] private Text debuggingValue;
    public Material mat;
    private bool placementPoseIsValid = false;
    private Pose placementPose;
    GameObject spawnableObject;
    
    public bool picked;

    // Start is called before the first frame update
    void Start()
    {
        picked = false;
        spawnableObject = null;
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid && picked)
        {
            //placementIndicator.transform.GetChild(0).transform.localScale = spawnablePrefab.transform.localScale;
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f,0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        arRaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon); // whether touch hits a detected plane plane

        placementPoseIsValid = hits.Count > 0;

        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);  
        }
        if (Input.touchCount > 0 && placementPoseIsValid && picked) // touch occured
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began) // check for a touch and no object have been instantiate before 
            {
                addLeanComponents(spawnablePrefab); // Add components to current prefab.
                SpawnPrefab(); // Instantiate an object in the ar scene
                                                    //setMaterial(mat);
                picked = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();
    }

    private GameObject SpawnPrefab()
    {
       return spawnableObject = Instantiate(spawnablePrefab, placementPose.position, placementPose.rotation);
    }

    private void setMaterial(GameObject gameObject,Material material)
    {
        Renderer rend = gameObject.GetComponent<Renderer>();
        rend.enabled = true;
        Material[] materials = new Material[rend.sharedMaterials.Length];
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i] = material;
        }

        rend.sharedMaterials = materials;
    }
    private void addLeanComponents(GameObject prefab)
    {
        //prefab.AddComponent<LeanSelectable>();
        
        

        var leanTranslate = prefab.GetComponent<LeanDragTranslate>();
        var leanRotate = prefab.GetComponent<LeanTwistRotateAxis>();
        var rigidBody = prefab.GetComponent<Rigidbody>();
        VerticalPositionCalc positionCalc = prefab.GetComponent<VerticalPositionCalc>();

        if (prefab.GetComponent<LeanSelectableOutline>() == null)
        {
            prefab.AddComponent<LeanSelectableOutline>();
        }
        if (prefab.GetComponent<LeanSelectableByFinger>() == null)
        {
            prefab.AddComponent<LeanSelectableByFinger>();
        }
        if (leanTranslate == null)
        {
            prefab.AddComponent<LeanDragTranslate>();
            prefab.GetComponent<LeanDragTranslate>().Use.RequiredFingerCount = 1;
            prefab.GetComponent<LeanDragTranslate>().Camera = GameObject.Find("AR Camera").GetComponent<Camera>();
            prefab.GetComponent<LeanDragTranslate>().Sensitivity = 2;
        }
        if (leanRotate == null)
        {
            prefab.AddComponent<LeanTwistRotateAxis>();
            prefab.GetComponent<LeanTwistRotateAxis>().Sensitivity = 2;
        }
        if (prefab.GetComponent<saveYLocation>() == null)
        {
            prefab.AddComponent<saveYLocation>();
        }
            
        if (prefab.GetComponent<BoxCollider>() == null)
        {
            prefab.AddComponent<BoxCollider>();
        }
        if (rigidBody == null)
        {
            prefab.AddComponent<Rigidbody>();
            prefab.GetComponent<Rigidbody>().useGravity = false;
            prefab.GetComponent<Rigidbody>().drag = float.MaxValue;
            prefab.GetComponent<Rigidbody>().angularDrag = float.MaxValue;
            prefab.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
            prefab.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
        }
           
        

        if (prefab.GetComponent<Outline1>() == null)
        {
            var outline = prefab.AddComponent<Outline1>();

            outline.OutlineMode = Outline1.Mode.OutlineVisible;
            outline.OutlineColor = Color.cyan;
            outline.OutlineColor2 = Color.red;
            outline.OutlineWidth = 5f;
            outline.enabled = false;
        }

        if (positionCalc == null)
        {
            var comp = prefab.AddComponent<VerticalPositionCalc>();
            comp.setRayCastManager(arRaycastManager);
        }
        
        prefab.tag = "FurnitureModels";

        debuggingValue.text = "components added";
    }

}