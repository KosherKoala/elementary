using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainSourceTriggerable : MonoBehaviour
{
    
    public Transform emissionPoint;
    private bool triggered;

    public void Initialize()
    {

    }

    private void Update()
    {
       
    }

    public void Trigger()
    {
        triggered = true;
    }

    public void Cancel()
    {
        triggered = false;
    }

    public bool IsTriggered()
    {
        return triggered;
    }

    public Element Drain(ElementSource source)
    {
        return source.Drain();
    }
}
