using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gesture {

    public GZone zone;
    public Grip grip;

    public Gesture(GZone zone, Grip grip)
    {
        this.zone = zone;
        this.grip = grip;
    }
}
