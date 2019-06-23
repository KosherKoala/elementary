using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neutral : CastingNode {

    private ElementNeutral elementNeutral;
    private RaycastAbilityTriggerable raycastAbilityTriggerable;
    private DrainSourceTriggerable drainSourceTriggerable;
    private ElementSource currentSource = null;

    public override void Initialize(CastingNode head, BenderGrabber grabber, GestureManager gestureManager, ElementManager elementManager)
    {
        this.head = head;
        nName = "Neutral";
        nGrabber = grabber;
        this. gestureManager = gestureManager;
        this.elementManager = elementManager;

        elementNeutral = new ElementNeutral();
        elementNeutral.Initialize(head, grabber, gestureManager, elementManager);

        raycastAbilityTriggerable = grabber.GetComponent<RaycastAbilityTriggerable>();
        raycastAbilityTriggerable.Initialize();
        drainSourceTriggerable = grabber.GetComponent<DrainSourceTriggerable>();

    }

    public override CastingNode AttemptNextLeft()
    {
        if (!raycastAbilityTriggerable.isTriggered())
        {
            raycastAbilityTriggerable.Trigger();
        }
        
        GameObject sourceObject = raycastAbilityTriggerable.GetHitObject();
        ElementSource source = null;

        if (gestureManager.GetGripLeft() == Grip.BOTTOM)
        {
            raycastAbilityTriggerable.ToggleLine();
        }

        if (sourceObject != null && sourceObject.GetComponent<ElementSource>())
        {
            source = raycastAbilityTriggerable.GetHitObject().GetComponent<ElementSource>();
        }

        if (source != null)
        {
            Debug.Log("Source Found");
            currentSource = source;
            source.transform.Find("Crosshair").GetComponent<SourceCrosshair>().SetState(CrosshairState.Targeted);
            if (!drainSourceTriggerable.IsTriggered())
            {
                drainSourceTriggerable.Trigger();
            }
            if (gestureManager.GetGripLeft() == Grip.HAND && drainSourceTriggerable.IsTriggered())
            {
                elementManager.elementL = drainSourceTriggerable.Drain(source);
            }
        }
        else
        {
            if (currentSource) { 
                currentSource.transform.Find("Crosshair").GetComponent<SourceCrosshair>().SetState(CrosshairState.Disabled);
                currentSource = null;
            }
            drainSourceTriggerable.Cancel();
        }
        
        if (elementManager.elementL != null)
        {
            raycastAbilityTriggerable.Cancel();
            drainSourceTriggerable.Cancel();
            source.transform.Find("Crosshair").GetComponent<SourceCrosshair>().SetState(CrosshairState.Disabled);
            return elementNeutral;
        }
        return this;
    }

    public override CastingNode AttemptNextRight()
    {
        if (!raycastAbilityTriggerable.isTriggered())
        {
            raycastAbilityTriggerable.Trigger();
        }

        GameObject sourceObject = raycastAbilityTriggerable.GetHitObject();
        ElementSource source = null;

        if (gestureManager.GetGripRight() == Grip.BOTTOM)
        {
            raycastAbilityTriggerable.ToggleLine();
        }

        if (sourceObject != null && sourceObject.GetComponent<ElementSource>())
        {
            source = raycastAbilityTriggerable.GetHitObject().GetComponent<ElementSource>();
        }

        if (source != null)
        {
            Debug.Log("Source Found");
            currentSource = source;
            source.transform.Find("Crosshair").GetComponent<SourceCrosshair>().SetState(CrosshairState.Targeted);
            if (!drainSourceTriggerable.IsTriggered())
            {
                drainSourceTriggerable.Trigger();
            }
            if (gestureManager.GetGripRight() == Grip.HAND && drainSourceTriggerable.IsTriggered())
            {
                elementManager.elementR = drainSourceTriggerable.Drain(source);
            }
        }
        else
        {
            if (currentSource)
            {
                currentSource.transform.Find("Crosshair").GetComponent<SourceCrosshair>().SetState(CrosshairState.Disabled);
                currentSource = null;
            }
            drainSourceTriggerable.Cancel();
        }

        if (elementManager.elementR != null)
        {
            raycastAbilityTriggerable.Cancel();
            drainSourceTriggerable.Cancel();
            source.transform.Find("Crosshair").GetComponent<SourceCrosshair>().SetState(CrosshairState.Disabled);
            return elementNeutral;
        }
        return this;
    }
}
