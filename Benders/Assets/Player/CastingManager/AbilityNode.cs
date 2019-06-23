using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbiltiyNode : CastingNode {

    protected Ability ability;

    public abstract void Initialize(CastingNode head, BenderGrabber grabber, Ability ability);
}
