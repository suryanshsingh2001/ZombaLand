using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;

    [SerializeField] AudioClip pickupSound;

    AudioSource audioSource;

    private void Start()
    {
         audioSource = GetComponentInParent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType,ammoAmount);
            Debug.Log("Sounds");
            audioSource.PlayOneShot(pickupSound);
            Destroy(gameObject);
        }
    }
}
