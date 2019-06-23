using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eState
{
    SOLID,
    LIQUID,
    GAS
}

public abstract class Element : ScriptableObject {
    public string eName = "New Element";
    public float eTemperature;
    public eState eState;
    public float eMass;

    [HideInInspector] public Color color;


    public abstract void Initialize();
    public abstract Color GetColor();
  
}
