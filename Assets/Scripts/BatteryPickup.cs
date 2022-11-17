using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 90f;
    [SerializeField] float addIntensity = 1f;
    [SerializeField] AudioClip batteryPickupSound;


    PlayerHealth player;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponentInParent<AudioSource>();
        player = FindObjectOfType<PlayerHealth>();
    }
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Sounds");
            other.GetComponentInChildren<Flashlight>().RestoreLightAngle(restoreAngle);
            other.GetComponentInChildren<Flashlight>().AddLightIntensity(addIntensity);
            player.GiveHealth();
            audioSource.PlayOneShot(batteryPickupSound);
            Destroy(gameObject);
        }
    }
}
