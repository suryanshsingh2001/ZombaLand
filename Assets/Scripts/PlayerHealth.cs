using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 400f;
    [SerializeField] TextMeshProUGUI healthBar;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip hitSound;
    

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        

    }
    private void Update()
    {
        DisplayHealth();
    }

    public void DisplayHealth()
    {
        float currentHealth = hitPoints / 4;
        healthBar.text = currentHealth.ToString();
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
    public void GiveHealth()
    {
        hitPoints = 400f;
    }

}
