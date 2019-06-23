using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DynamicElement : Element {

   public abstract void Initialize(float temperature, eState state, float mass);
}
