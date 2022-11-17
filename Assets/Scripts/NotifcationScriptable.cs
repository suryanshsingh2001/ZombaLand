using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "NotificationSc")]
public class NotifcationScriptable:ScriptableObject
{
   
    [Header("Message Customization")]
    [SerializeField][TextArea] public string notificationMessage;

    [Header("Notification Removal")]
    [SerializeField]  public bool removeAfterExit = false;
    [SerializeField] public bool disableAfterTimer = false;
    [SerializeField] public float disableTimer = 0.1f;

   
}
