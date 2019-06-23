using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingManager : MonoBehaviour {

    public GestureManager gestureManager;
    public GestureProjector gestureProjector;

    public ElementManager elementManager;

    private CastingNode headLeft;
    private CastingNode headRight;
    private CastingNode currentNodeLeft;
    private CastingNode currentNodeRight;


    // Use this for initialization
    void Start () { 

        headLeft = new Neutral();
        headLeft.Initialize(headLeft, gestureManager.grabberLeft, gestureManager, elementManager);

        headRight = new Neutral();
        headRight.Initialize(headRight, gestureManager.grabberRight, gestureManager, elementManager);

        currentNodeLeft = headLeft;
        currentNodeRight = headRight;
        
        Debug.Log(currentNodeLeft);
        Debug.Log(currentNodeRight);
    }
	
	// Update is called once per frame
	void Update () {
        currentNodeLeft = currentNodeLeft.AttemptNextLeft();
        currentNodeRight = currentNodeRight.AttemptNextRight();

        gestureProjector.SetCastingStateLeft(currentNodeLeft.nName);
        gestureProjector.SetCastingStateRight(currentNodeRight.nName);
    }
    
}
