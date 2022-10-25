using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;


    [SerializeField] AudioClip weaponSwitchSound;


    AudioSource audioSource;



    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SetWeaponActive();
    }

    void Update()
    {
        int previousWeapon = currentWeapon;

        ProceesKeyInput();
        ProceesScrollWheel();

        if (previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
      
    }

    void ProceesScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            audioSource.PlayOneShot(weaponSwitchSound);
            if (currentWeapon >= transform.childCount - 1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            audioSource.PlayOneShot(weaponSwitchSound);
            if (currentWeapon <= 0) 
            {
                currentWeapon = transform.childCount - 1;
            }
            else
            {
                currentWeapon--;
            }
        }
    }

    void ProceesKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        } 
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        } 
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach(Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            
            weaponIndex++;
        }
    }

    
}
