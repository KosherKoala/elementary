using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAbility : Ability {

    private RaycastAbilityTriggerable raycastTriggerable;

    public override void Initialize(GameObject obj)
    {
        raycastTriggerable = obj.GetComponent<RaycastAbilityTriggerable>();
        raycastTriggerable.Initialize();
    }

    public override void TriggerAbility()
    {
        triggered = true;
        raycastTriggerable.Trigger();
    }

    public override void CancelAbility()
    {
        triggered = false;
        raycastTriggerable.Cancel();
    }
}
