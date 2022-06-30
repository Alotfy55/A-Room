using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sofa_loader : MonoBehaviour
{
    public GameObject b;
    public GameObject c;
    public GameObject spawner;
    public GameObject slider;
    public Button cancel;

    public void Create()
    {
        cancel.gameObject.SetActive(true);
        SpawnableObject temp = spawner.GetComponent<SpawnableObject>();
        temp.spawnablePrefab = b;
        temp.placementIndicator = c;

        
        
        spawner.GetComponent<SpawnableObject>().picked = true;
        slider.GetComponent<Button>().onClick.Invoke();

    }
}
