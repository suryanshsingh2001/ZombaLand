using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController firstPersonController;

    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomedOutSensivity = 2f;
    [SerializeField] float zoomedInSensivity = 0.5f;
    
    bool zoomedInToogle = false;


    private void OnDisable()
    {
        ZoomOut();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!zoomedInToogle)
            {
                ZoomIn();
            }
            else if (zoomedInToogle)
            {
                ZoomOut();
            }
        }
    }

    private void ZoomOut()
    {
        zoomedInToogle = false;
        fpsCamera.fieldOfView = zoomedOutFOV;
        firstPersonController.mouseLook.XSensitivity = zoomedOutSensivity;
        firstPersonController.mouseLook.YSensitivity = zoomedOutSensivity;
    }

    private void ZoomIn()
    {
        zoomedInToogle = true;
        fpsCamera.fieldOfView = zoomedInFOV;
        firstPersonController.mouseLook.XSensitivity = zoomedInSensivity;
        firstPersonController.mouseLook.YSensitivity = zoomedInSensivity;
    }
}
