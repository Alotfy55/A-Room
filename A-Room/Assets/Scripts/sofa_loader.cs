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
        //GameObject a = (GameObject)Instantiate(b);
        cancel.gameObject.SetActive(true);
        SpawnableObject temp = spawner.GetComponent<SpawnableObject>();
        temp.scale = b.GetComponent<Renderer>().bounds.size;
        //temp.newScale(temp.placementIndicator.transform.GetChild(0).gameObject, temp.scale);
        temp.spawnablePrefab = b;
        temp.placementIndicator = c;

        
        
        spawner.GetComponent<SpawnableObject>().picked = true;
        slider.GetComponent<Button>().onClick.Invoke();
        //shootButton = GameObject.FindGameObjectWithTag("ShootButton");
        //shootButton.onClick.Invoke();
        ////a.transform.SetParent(panel.transform);
    }
}
