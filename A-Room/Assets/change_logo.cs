using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_logo : MonoBehaviour
{

    public Sprite sprite1;
    public Sprite sprite2;
    public Button button;


    void Start()
    {
        
    }

    void Update()
    {

    }

    public void ChangeTheSprite()
    {
        
        button = GetComponent<Button>();

        if (button.image.sprite == sprite1)
            button.image.sprite = sprite2;
        else
            button.image.sprite = sprite1;
    }
}
