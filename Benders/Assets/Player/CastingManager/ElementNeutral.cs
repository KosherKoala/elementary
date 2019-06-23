using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementNeutral : CastingNode {

    private SelfSource selfSource;

    public override void Initialize(CastingNode head, BenderGrabber grabber, GestureManager gestureManager, ElementManager elementManager)
    {
        this.head = head;
        nName = "ElementNeutral";
        this.gestureManager = gestureManager;
        this.elementManager = elementManager;

        selfSource = new SelfSource();
        selfSource.Initialize(head, grabber, gestureManager, elementManager);
    }

    public override CastingNode AttemptNextLeft()
    {
        Gesture gesture = gestureManager.GetGestureLeft();
        if (gesture.grip == Grip.FULL && gesture.zone == GZone.TORSO)
        {
            return selfSource;
        }
        return this;
    }

    public override CastingNode AttemptNextRight()
    {
        Gesture gesture = gestureManager.GetGestureRight();
        if (gesture.grip == Grip.FULL && gesture.zone == GZone.TORSO)
        {
            return selfSource;
        }
        return this;
    }
}
