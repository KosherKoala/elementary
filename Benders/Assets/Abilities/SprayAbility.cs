using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayAbility : Ability {
    

    public override void Initialize(GameObject obj)
    {
    }

    public override void TriggerAbility()
    {
        triggered = true;
    }

    public override void CancelAbility()
    {
        triggered = false;
    }

}
