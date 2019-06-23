using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementPedestal : MonoBehaviour {

    public FusionManager fusionManager;
    public ElementOrb elementOrbPrefab;
    public Transform spawnpoint;
    public bool spawn = true;
    public bool floater = true;


    // Float stuff
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.05f;
    public float frequency = 1f;
    private GameObject floatee;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start () {
        if (spawn)
        {
            ElementOrb orb = Instantiate(elementOrbPrefab, spawnpoint.position, spawnpoint.rotation);
            orb.fusionManager = fusionManager;
        }
        posOffset = spawnpoint.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (floatee != null && floater)
        {
            if (!floatee.gameObject.GetComponent<OVRGrabbable>().isGrabbed)
            {
                //floatee.transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

                tempPos = posOffset;
                tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

                floatee.transform.position = tempPos;

            }
            else
            {
                floatee = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        checkForNewFloatee(other);
    }

    private void OnTriggerStay(Collider other)
    {
        checkForNewFloatee(other);
    }


    private void checkForNewFloatee(Collider other)
    {
        if (floatee == null && floater)
        {
            if (other.gameObject.GetComponent<ElementOrb>())
            {
                floatee = other.gameObject;
            }
        }
    }
}
