﻿using System.Collections;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    [SerializeField] private Material sky;
    [SerializeField] private Light sun;

    private float _fullIntensity;
    private float _cloudValue = 0f;

    private void Start()
    {
        _fullIntensity = sun.intensity;
    }

    void Update()
    {
        SetOvercast(_cloudValue);
        _cloudValue += .001f;
        if (_cloudValue > 1f)
        {
            _cloudValue = -1f;
        }
    }

    private void SetOvercast(float value)
    {
        sky.SetFloat("_Blend", value);
        sun.intensity = _fullIntensity - (_fullIntensity * value);
    }
}
