using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZoneTriggerType
{
    ENTER,
    EXIT
}

public class GestureZone : MonoBehaviour {

    public GZone gZone;

    private GestureManager gestureManager;
    

    void Start()
    {
        gestureManager = transform.GetComponentInParent<GestureManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BenderGrabber>())
        {
            gestureManager.SetGZone(gZone, other.gameObject);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<BenderGrabber>())
        {
            gestureManager.SetGZone(gZone, other.gameObject);
        }

    }


}
