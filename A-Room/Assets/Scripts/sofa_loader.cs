using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sofa_loader : MonoBehaviour
{
    public GameObject b;
    public GameObject spawner;
    public GameObject slider;
    public Button cancel;
    public void Create()
    {
        //GameObject a = (GameObject)Instantiate(b);
        cancel.gameObject.SetActive(true);
        spawner.GetComponent<SpawnableObject>().scale = b.GetComponent<Renderer>().bounds.size;
        spawner.GetComponent<SpawnableObject>().spawnablePrefab = b;
        spawner.GetComponent<SpawnableObject>().picked = true;
        slider.GetComponent<Button>().onClick.Invoke();
        //shootButton = GameObject.FindGameObjectWithTag("ShootButton");
        //shootButton.onClick.Invoke();
        ////a.transform.SetParent(panel.transform);
    }
}
