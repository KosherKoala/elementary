using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfSource : CastingNode {

    private SprayNode spray;

    public override void Initialize(CastingNode head, BenderGrabber grabber, GestureManager gestureManager, ElementManager elementManager)
    {
        this.head = head;
        nName = "SelfSource";
        this.gestureManager = gestureManager;
        this.elementManager = elementManager;

        spray = new SprayNode();
        spray.Initialize(head, grabber, gestureManager, elementManager);
    }

    public override CastingNode AttemptNextLeft()
    {
        Gesture gesture = gestureManager.GetGestureLeft();
        if (gesture.grip == Grip.EMPTY)
        {
            return spray;
        }
        return this;
    }

    public override CastingNode AttemptNextRight()
    {
        Gesture gesture = gestureManager.GetGestureRight();
        if (gesture.grip == Grip.EMPTY)
        {
            return spray;
        }
        return this;
    }
}
