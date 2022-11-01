using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
   
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] AudioClip walkingSound;
    

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    AudioSource audioSource;
    bool isProvoked = false;

    EnemyHealth health;
    Transform target;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
        audioSource = GetComponent<AudioSource>();
       ;
    }


    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            //You can add alarm sound or any other ways to provoke the enemy here
  
        }

    }
    public void OnDamageTaken()
    {
        isProvoked = true;

    }

    void EngageTarget()
    {
        FaceTarget();
       
        if (distanceToTarget >= navMeshAgent.stoppingDistance) 
        {
            ChaseTarget();

        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance) 
        {
            AttackTarget();
        }
    }

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
       

    }

    void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        
        

        navMeshAgent.SetDestination(target.position);
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    

}
