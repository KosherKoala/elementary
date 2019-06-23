using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainAbility : Ability
{

    private DrainSourceTriggerable drainTriggerable;

    public override void Initialize(GameObject obj)
    {
        drainTriggerable = obj.GetComponent<DrainSourceTriggerable>();
        drainTriggerable.Initialize();
    }

    public override void TriggerAbility()
    {
        triggered = true;
        drainTriggerable.Trigger();
    }

    public override void CancelAbility()
    {
        triggered = false;
        drainTriggerable.Cancel();
    }

}