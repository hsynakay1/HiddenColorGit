using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SliderColor : MonoBehaviour
{
    private float hsv;
    public Slider slider;
    public Material material;
    void Start()
    {
        slider.maxValue = 1;
        slider.minValue = 0;
    }
    public void SliderHSV()
    {
        hsv = slider.normalizedValue;
        material.color = Color.HSVToRGB(1-hsv,1,1); 
    }
    
}

