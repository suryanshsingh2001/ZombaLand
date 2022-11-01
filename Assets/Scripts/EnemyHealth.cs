using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip hitSound;

   
    AudioSource audioSource;

    bool isDead = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        audioSource.PlayOneShot(hitSound);

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if(isDead) { return; }

        isDead = true;
        audioSource.PlayOneShot(deathSound);
        GetComponent<Animator>().SetTrigger("Die");
       
        
    }
}
