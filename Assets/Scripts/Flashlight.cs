using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;


    Light light;


    private void Start()
    {
        light = GetComponent<Light>();
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        light.spotAngle = restoreAngle;
    }

    public void AddLightIntensity(float intensiyAmount)
    {
        light.intensity += intensiyAmount;
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    private void DecreaseLightAngle()
    {
        if (light.spotAngle <= minimumAngle) { return; }
        else
        {
            light.spotAngle -= angleDecay * Time.deltaTime;
        }
    }

    private void DecreaseLightIntensity()
    {
        light.intensity -= lightDecay * Time.deltaTime;
        
    }
}
