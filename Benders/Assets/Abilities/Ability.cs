using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject {

    public string aName = "New Ability";
    protected bool triggered = false;

    public abstract void Initialize(GameObject obj);

    public abstract void TriggerAbility();
    public abstract void CancelAbility();


    public bool isTriggered()
    {
        return triggered;
    }

}
