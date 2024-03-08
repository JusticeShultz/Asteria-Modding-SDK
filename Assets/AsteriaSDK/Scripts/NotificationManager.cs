using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager Instance;

    public Transform notificationModule;
    public Transform nextNotificationVector;
    public GameObject notificationTemplate;
    //public TMPro.TextMeshProUGUI templateText;
    public List<GameObject> currentNotifications = new List<GameObject>();

    void Start()
    {
    }

    [Button]
    public void PushNotification(string notification)
    {
    }

    public static void Notify(string notification)
    {
    }
}
