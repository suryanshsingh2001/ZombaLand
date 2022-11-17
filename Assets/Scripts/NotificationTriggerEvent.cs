using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NotificationTriggerEvent : MonoBehaviour
{
    [Header("UI Content")]
    [SerializeField] TextMeshProUGUI notificationText;
    

    [Header("Message Customization")]
    
    [SerializeField][TextArea] string notificationMessage;

    [Header("Notification Removal")]
    [SerializeField] bool removeafterExit = false;
    [SerializeField] bool disableAfterTimer = false;
    [SerializeField] float disableTimer = 0.1f;

    [Header("Notification Animation")]
    [SerializeField] Animator notificationAnim;


    BoxCollider objectCollider;


    private void Awake()
    {
        objectCollider = gameObject.GetComponent<BoxCollider>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && removeafterExit)
        {
            StartCoroutine(EnableNotification());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && removeafterExit)
        {
            RemoveNotification();
        }
    }

    IEnumerator EnableNotification()
    {
        objectCollider.enabled = false;
        notificationAnim.Play("Fade In");
        notificationText.text = notificationMessage;


        if (disableAfterTimer)
        {
            yield return new WaitForSeconds(disableTimer);
            RemoveNotification();
        }
        
    }

    private void RemoveNotification()
    {
        notificationAnim.Play("Fade Out");
        gameObject.active = false;
    }
}
