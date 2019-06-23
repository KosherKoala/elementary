using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Grip
{
    EMPTY,
    INDEX,
    HAND,
    FULL,
    TOP,
    BOTTOM,
    CANCEL
}

public enum GZone
{
    HEAD,
    TORSO,
    LEGS,
    NONE
}


public class GestureManager : MonoBehaviour {

    // Player
    public OVRPlayerController player;
    public GameObject centerEyeAnchor;

    // GestureZones
    private GestureZone head;
    private GestureZone torso;
    private GestureZone legs;
    private GZone leftZone = GZone.NONE;
    private GZone rightZone = GZone.NONE;

    // Grabbers and States
    public BenderGrabber grabberLeft;
    public BenderGrabber grabberRight;

    // Grip Inputs
    private OVRInput.Button handTrigger = OVRInput.Button.PrimaryHandTrigger;
    private OVRInput.Button indexTrigger = OVRInput.Button.PrimaryIndexTrigger;
    private OVRInput.Button thumbStick = OVRInput.Button.PrimaryThumbstick;
    private OVRInput.Button topButton = OVRInput.Button.Two;
    private OVRInput.Button bottomButton = OVRInput.Button.One;
    

    // Projector
    public GestureProjector gestureProjector;

    // Use this for initialization
    void Start () {
        head = transform.Find("GestureZone.Head").gameObject.GetComponent<GestureZone>();
        torso = transform.Find("GestureZone.Torso").gameObject.GetComponent<GestureZone>();
        legs = transform.Find("GestureZone.Legs").gameObject.GetComponent<GestureZone>();
        UpdateGestureZoneTransforms();
    }
	
	// Update is called once per frame
	void Update () {

        UpdateGestureZoneTransforms();
        GetGripLeft();
        GetGripRight();

        gestureProjector.SetZoneRight(rightZone.ToString());
        gestureProjector.SetZoneLeft(leftZone.ToString());

    }

    public Gesture GetGestureRight()
    {
        return new Gesture(rightZone, GetGripRight());
    }

    public Gesture GetGestureLeft()
    {
        return new Gesture(leftZone, GetGripLeft());
    }

    private void UpdateGestureZoneTransforms()
    {
        Vector3 torsoOffset = new Vector3(0, -0.5f, 0);
        Vector3 legsOffset = new Vector3(0, -1f, 0);
        
        head.transform.position = centerEyeAnchor.transform.position;
        torso.transform.position = centerEyeAnchor.transform.position + torsoOffset;
        legs.transform.position = centerEyeAnchor.transform.position + legsOffset;
       
    }

    public Grip GetGripLeft()
    {
        bool handL = OVRInput.Get(handTrigger, grabberLeft.GetController());
        bool indexL = OVRInput.Get(indexTrigger, grabberLeft.GetController());
        bool thumbStickL = OVRInput.Get(thumbStick, grabberLeft.GetController());
        bool topL = OVRInput.Get(topButton, grabberLeft.GetController());
        bool bottomL = OVRInput.Get(bottomButton, grabberLeft.GetController());

        if (topL)
        {
            gestureProjector.SetTextLeft(Grip.TOP.ToString());
            return Grip.TOP;
        }

        if (bottomL)
        {
            gestureProjector.SetTextLeft(Grip.BOTTOM.ToString());
            return Grip.BOTTOM;
        }

        if (thumbStickL)
        {
            gestureProjector.SetTextLeft(Grip.CANCEL.ToString());
            return Grip.CANCEL;
        }

        if (indexL && handL)
        {
            gestureProjector.SetTextLeft(Grip.FULL.ToString());
            return Grip.FULL;
        }
        else if (indexL)
        {
            gestureProjector.SetTextLeft(Grip.INDEX.ToString());
            return Grip.INDEX;
        }
        else if (handL)
        {
            gestureProjector.SetTextLeft(Grip.HAND.ToString());
            return Grip.HAND;
        }
        else
        {
            gestureProjector.SetTextLeft(Grip.EMPTY.ToString());
            return Grip.EMPTY;
        }
    }

    public Grip GetGripRight()
    {
        bool handR = OVRInput.Get(handTrigger, grabberRight.GetController());
        bool indexR = OVRInput.Get(indexTrigger, grabberRight.GetController());
        bool cancel = OVRInput.Get(thumbStick, grabberRight.GetController());

        if (cancel)
        {
            gestureProjector.SetTextRight(Grip.CANCEL.ToString());
            return Grip.CANCEL;
        }

        if (indexR && handR)
        {
            gestureProjector.SetTextRight(Grip.FULL.ToString());
            return Grip.FULL;
        }
        else if (indexR)
        {
            gestureProjector.SetTextRight(Grip.INDEX.ToString());
            return Grip.INDEX;
        }
        else if (handR)
        {
            gestureProjector.SetTextRight(Grip.HAND.ToString());
            return Grip.HAND;
        }
        else
        {
            gestureProjector.SetTextRight(Grip.EMPTY.ToString());
            return Grip.EMPTY;
        }
    }

    public void SetGZone(GZone zone, GameObject hand)
    {
        if (hand.GetInstanceID().Equals(grabberLeft.gameObject.GetInstanceID()))
        {
            leftZone = zone;
        }
        else if (hand.GetInstanceID().Equals(grabberRight.gameObject.GetInstanceID()))
        {
            rightZone = zone;
        }
    }
}
