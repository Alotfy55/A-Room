using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Common;
using Lean.Touch;

public class LeanSelectableOutline : LeanSelectableBehaviour
{
    

    protected virtual void Awake()
    {
        
    }

    protected override void OnSelected(LeanSelect select)
    {
        this.gameObject.GetComponent<Outline1>().enabled = true;
    }

    protected override void OnDeselected(LeanSelect select)
    {
        this.gameObject.GetComponent<Outline1>().enabled = false;
    }
}
