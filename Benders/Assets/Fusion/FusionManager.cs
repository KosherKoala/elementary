using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusionManager : MonoBehaviour {

    public ElementOrb elementOrbPrefab;
    private List<int> ids = new List<int>();
    private BenderGrabber parent;


    public void FuseElements(GameObject orb1, GameObject orb2)
    {
        int id1 = orb1.GetInstanceID(), id2 = orb2.GetInstanceID(); ;

        // If they have already been found
        if(ids.Exists(id => id ==id1) && ids.Exists(id => id == id2)){

            Element e1 = orb1.GetComponent<ElementOrb>().element;
            Element e2 = orb2.GetComponent<ElementOrb>().element;

            float fusedTemp = fuseTemp(e1, e2);
            eState fusedState = fuseState(e1, e2);
            float fusedMass = fuseMass(e1, e2);

            FusionElement fusionElement = ScriptableObject.CreateInstance<FusionElement>();
            fusionElement.Initialize(fusedTemp, fusedState, fusedMass);

            Debug.Log("New Temp: "  + fusionElement.eTemperature + " " + fusedTemp);

       /*     ElementOrb fusionOrb = Instantiate(elementOrbPrefab, parent.transform.Find("palm").transform);
            fusionOrb.Initialize(fusionElement, this);*/

            ElementManager elementManager = transform.parent.GetComponentInChildren<ElementManager>();
            elementManager.DestroyElements();
            if (parent.CompareTag("HandLeft"))
            {
                elementManager.elementL = fusionElement;
            }
            else if (parent.CompareTag("HandRight"))
            {
                elementManager.elementR = fusionElement;
            }

        } else
        {
            // If not add them to list
            ids.Add(id1);
            ids.Add(id2);
            parent = orb1.GetComponentInParent<BenderGrabber>();
        }
    }

    private float fuseTemp(Element e1, Element e2)
    {
        float temp1 = e1.eTemperature;
        float temp2 = e2.eTemperature;

        return (temp1 + temp2) / 2;
    }

    private eState fuseState(Element e1, Element e2)
    {

        if(e1.eState == e2.eState)
        {
            return e1.eState;
        }
        else
        {
            switch (e1.eState)
            {
                case eState.SOLID:
                    if(e2.eTemperature > e1.eTemperature)
                    {
                        return eState.LIQUID;
                    }
                    return eState.SOLID;
                case eState.LIQUID:
                    if (e2.eTemperature > e1.eTemperature)
                    {
                        return eState.GAS;
                    }
                    if (e2.eTemperature < e1.eTemperature)
                    {
                        return eState.SOLID;
                    }
                    return eState.LIQUID;
                case eState.GAS:
                    if (e2.eTemperature < e1.eTemperature)
                    {
                        return eState.LIQUID;
                    }
                    return eState.GAS;
                default:
                    return e1.eState;
            }
        }
    }

    private float fuseMass(Element e1, Element e2)
    {
        return e1.eMass + e1.eMass;
    }
}
