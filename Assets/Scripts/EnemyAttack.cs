using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 40f;
    [SerializeField] AudioClip provokedSound;

    AudioSource audioSource;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        audioSource = GetComponent<AudioSource>();
    }

    public void AttackHitEvent()
    {
        if (target == null)   {  return;   }
        target.TakeDamage(damage);
        audioSource.PlayOneShot(provokedSound, 0.2f);
        target.GetComponent<DamageDisplayer>().ShowDamageImpact();
    }

    
}
