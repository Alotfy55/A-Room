using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_logo : MonoBehaviour
{

    public Sprite Up_Arrow;
    public Sprite Down_Arrow;
    public Button Slider_Button;
    public void ChangeTheSprite()
    {
        Slider_Button = GetComponent<Button>();

        if (Slider_Button.image.sprite == Up_Arrow)
            Slider_Button.image.sprite = Down_Arrow;
        else
            Slider_Button.image.sprite = Up_Arrow;
    }
}
