using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CastingNode {
    public string nName;
    protected CastingNode head;
    protected BenderGrabber nGrabber;
    protected GestureManager gestureManager;
    protected ElementManager elementManager;

    public abstract void Initialize(CastingNode head, BenderGrabber grabber, GestureManager gestureManager, ElementManager elementManager);
    public abstract CastingNode AttemptNextLeft();
    public abstract CastingNode AttemptNextRight();
}
