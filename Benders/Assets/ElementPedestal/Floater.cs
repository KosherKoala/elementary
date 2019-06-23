

using UnityEngine;
using System.Collections;

public class Floater : MonoBehaviour
{
    // User Inputs
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.05f;
    public float frequency = 1f;
    public GameObject floatee;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = floatee.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Spin object around Y-Axis
        floatee.transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        floatee.transform.position = tempPos;
    }
}
