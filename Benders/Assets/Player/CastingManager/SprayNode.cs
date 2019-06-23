using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayNode : CastingNode {

    SprayTriggerable sprayAbilityTriggerable;

    public override void Initialize(CastingNode head, BenderGrabber grabber, GestureManager gestureManager, ElementManager elementManager)
    {
        this.head = head;
        nName = "Spray";
        this.gestureManager = gestureManager;
        this.elementManager = elementManager;

        sprayAbilityTriggerable = grabber.GetComponent<SprayTriggerable>();
        sprayAbilityTriggerable.Initialize();
    }

    public override CastingNode AttemptNextLeft( )
    {
        if (!sprayAbilityTriggerable.IsTriggered())
        {
            sprayAbilityTriggerable.Trigger(elementManager.elementL);
        }
        Gesture gesture = gestureManager.GetGestureLeft();
        if(gesture.grip == Grip.FULL)
        {
            if (sprayAbilityTriggerable.IsTriggered())
            {
                sprayAbilityTriggerable.Cancel();
                elementManager.elementL = null;
            }
            return head;
        }
        return this;
    }

    public override CastingNode AttemptNextRight()
    {
        if (!sprayAbilityTriggerable.IsTriggered())
        {
            sprayAbilityTriggerable.Trigger(elementManager.elementR);
        }
        Gesture gesture = gestureManager.GetGestureRight();
        if (gesture.grip == Grip.FULL)
        {
            if (sprayAbilityTriggerable.IsTriggered())
            {
                sprayAbilityTriggerable.Cancel();
                elementManager.elementR = null;
            }
            return head;
        }
        return this;
    }
}
