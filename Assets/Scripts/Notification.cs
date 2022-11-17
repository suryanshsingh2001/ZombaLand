using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Notification:MonoBehaviour
{
    [Header("UI Content")]
    [SerializeField] TextMeshProUGUI notificationText;


    [Header("Scriptable Object")]
    [SerializeField] NotifcationScriptable notification;

    [Header("Notification Animation")]
    [SerializeField] Animator notificationAnim;
    BoxCollider objectCollider;


    private void Awake()
    {
        objectCollider = gameObject.GetComponent<BoxCollider>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(EnableNotification());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && notification.removeAfterExit)
        {
            RemoveNotification();
        }
    }

    IEnumerator EnableNotification()
    {
        //objectCollider.enabled = false;
        notificationAnim.Play("Fade In");
        notificationText.text = notification.notificationMessage;


        if (notification.disableAfterTimer)
        {
            yield return new WaitForSeconds(notification.disableTimer);
            RemoveNotification();
        }

    }

    private void RemoveNotification()
    {
        notificationAnim.Play("Fade Out");
        //gameObject.active = false;
    }
}
