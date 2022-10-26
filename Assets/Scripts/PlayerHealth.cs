using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip hitSound;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        audioSource.PlayOneShot(hitSound);

        if (hitPoints <= 0)
        {
            audioSource.PlayOneShot(deathSound);
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
