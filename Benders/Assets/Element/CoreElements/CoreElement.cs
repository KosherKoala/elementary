using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Elements/CoreElement")]
public class CoreElement : Element {

    public override void Initialize()
    {
        throw new System.NotImplementedException();
    }

    public override Color GetColor()
    {
        Color baseColor = Color.black;
        
        if(eTemperature > 0)
        {
            baseColor.r += eTemperature;
        }
        else if(eTemperature < 0)
        {
            baseColor.b += -eTemperature;
        } 

        if(eState == eState.GAS)
        {
            baseColor.a = .25f;
        }
        else if (eState == eState.LIQUID)
        {
            baseColor.a = .75f;
        }

        return baseColor;
    }
}
