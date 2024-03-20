using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class UIDemo : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public SpriteRenderer sr;
    public Color start;
    public Color end;
    float interpolation;


    public void SliderValueHasChanged(Single value)
    {

        //Debug.Log(value);
        interpolation = value;

    }

    private void Update()
    {
        
        sr.color = Color.Lerp(start, end, (interpolation/60));
    }

    public void DropDownSelectionChanged(int value)
    {
        Debug.Log(dropdown.options[value].text);
    }

}
