using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementManager : MonoBehaviour {

    public BenderGrabber grabberL;
    public BenderGrabber grabberR;
    public ElementOrb orbPrefab;

    public Element elementL = null;
    public Element elementR = null;


    private ElementOrb orbL = null;
    private ElementOrb orbR = null;

    // Use this for initialization
    void Start () {
		if(elementL != null && orbL == null)
        {
            orbL = Instantiate(orbPrefab, grabberL.transform.Find("palm").transform);
            orbL.Initialize(elementL);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (elementL != null && orbL == null)
        {
            orbL = Instantiate(orbPrefab, grabberL.transform.Find("palm").transform);
            orbL.Initialize(elementL);
        }

        if (elementL == null && orbL != null)
        {
            Debug.Log("DESTROYING");
            Destroy(orbL.gameObject);
        }

        if (elementR != null && orbR == null)
        {
            orbR = Instantiate(orbPrefab, grabberR.transform.Find("palm").transform);
            orbR.Initialize(elementR);
        }

        if (elementR == null && orbR != null)
        {
            Debug.Log("DESTROYING");
            Destroy(orbR.gameObject);
        }
    }

    private void CreateElementOrb()
    {

    }
}
