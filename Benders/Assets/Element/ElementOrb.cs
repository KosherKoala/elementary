using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementOrb : MonoBehaviour {

    public GameObject textPrefab;
    private GameObject textInstance;
    public Vector3 textOffset;

    public Element element;

    public FusionManager fusionManager;

    private Color color;
    private ConstantForce gravity;
    private float mass;

    public GameObject psPrefab;
    public GameObject ps;
    [HideInInspector] public bool fusible;

    // Use this for initialization
    void Start()
    {
        textInstance = Instantiate(textPrefab, transform.position + textOffset, Quaternion.identity, transform);
        if (element != null)
        {
            textInstance.GetComponent<TextMesh>().text = element.eName + "\n Temperature: " + element.eTemperature;
            GetComponent<Renderer>().material.color = element.GetColor();
            fusible = true;
        }

        if(psPrefab != null)
        {
            ps = Instantiate(psPrefab, transform.position, transform.rotation);
        }
	}

    public void Initialize(Element e, FusionManager fm)
    {
        element = e;
        fusionManager = fm;
        GetComponent<Renderer>().material.color = element.GetColor();
        fusible = true;
    }

    private void Update()
    {
        if (element != null)
        {
            textInstance.GetComponent<TextMesh>().text = element.eName 
                + "\n Temperature: " + element.eTemperature 
                + "\n Mass: " + mass
                + "\n State: " + element.eState;
        }
        if (ps != null)
        {
            ps.transform.position = transform.position;
        }
    }



    private void OnTriggerEnter (Collider other)
    {
        GameObject otherOrb;

        if (other.gameObject.CompareTag("ElementOrb") && fusible)
        {
            otherOrb = other.gameObject;
            fusionManager.GetComponent<FusionManager>().FuseElements(gameObject, otherOrb);

        }
        
    }
}