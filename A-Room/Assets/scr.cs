using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Material[] material = this.gameObject.GetComponent<Renderer>().materials;
        Debug.Log(material.Length);
        for (int i = 0; i < material.Length; i++)
        {

            material[i].SetFloat("_Mode", 2);
            material[i].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            material[i].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            material[i].SetInt("_ZWrite", 0);
            material[i].DisableKeyword("_ALPHATEST_ON");
            material[i].EnableKeyword("_ALPHABLEND_ON");
            material[i].DisableKeyword("_ALPHAPREMULTIPLY_ON");
            material[i].renderQueue = 3000;

            material[i].color = new Color(material[i].color.r, material[i].color.g, material[i].color.b, 0.2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
