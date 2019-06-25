using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAbilityTriggerable : MonoBehaviour
{
    private bool triggered;
    private GameObject hitObject;

    public Transform emissionPoint;
    public LineRenderer line;

    public void Initialize()
    {
       
        line = Instantiate(line, emissionPoint.transform);
    }

    private void Update()
    {
       /* RaycastHit newHit;

        if (triggered)
        {
            Ray ray = new Ray(emissionPoint.position, emissionPoint.forward);
            if (Physics.Raycast(ray, out newHit))
            {
                line.SetPosition(0, emissionPoint.position);
                line.SetPosition(1, newHit.point);
                

                hitObject = newHit.transform.gameObject;
            } else
            {
                hitObject = null;
            }
        }*/

    }

    public void ToggleLine()
    {
        line.gameObject.SetActive(!line.gameObject.active);
    }

    public GameObject GetHitObject()
    {
        RaycastHit newHit;
        if (triggered)
        {
            Ray ray = new Ray(emissionPoint.position, emissionPoint.forward);
            if (Physics.Raycast(ray, out newHit))
            {
                line.SetPosition(0, emissionPoint.position);
                line.SetPosition(1, newHit.point);


                return newHit.transform.gameObject;
            }
        }
        return null;
    }

    public bool isTriggered()
    {
        return triggered;
    }

    public void Trigger()
    {
        triggered = true;
        line.gameObject.SetActive(true);
    }

    public void Cancel()
    {
        triggered = false;
        line.gameObject.SetActive(false);
    }
}
