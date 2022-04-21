using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class LightEstimation : MonoBehaviour
{
    [SerializeField]
    private ARCameraManager arCameraManager;


    private Light currentLight;

    private void Awake()
    {
        currentLight = GetComponent<Light>();
    }

    private void OnEnable()
    {
       arCameraManager.frameReceived += FramesUpdated;
    }

    private void OnDisable()
    {
       arCameraManager.frameReceived -= FramesUpdated;
    }

    private void FramesUpdated(ARCameraFrameEventArgs args) 
    {
        if (args.lightEstimation.averageBrightness.HasValue)
        {
            currentLight.intensity = args.lightEstimation.averageBrightness.Value;
        }
        if (args.lightEstimation.averageColorTemperature.HasValue)
        {
            currentLight.colorTemperature = args.lightEstimation.averageColorTemperature.Value;
        }
        if (args.lightEstimation.colorCorrection.HasValue)
        {
            currentLight.color = args.lightEstimation.colorCorrection.Value;
        }
    }
}
