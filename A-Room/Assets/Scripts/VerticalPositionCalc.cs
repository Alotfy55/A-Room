using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class VerticalPositionCalc : MonoBehaviour
{
    private ARRaycastManager arRaycastManager;
    public void setRayCastManager(ARRaycastManager arRaycastManager)
    {
        this.arRaycastManager = arRaycastManager;
    }
}
