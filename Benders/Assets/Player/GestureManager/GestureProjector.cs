using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureProjector : MonoBehaviour {

    public TextMesh textPrefab;
    private TextMesh textInstance;
    public Vector3 offset;

    private string defaultText = "Waiting For Input";

    private string rightGrip = "Waiting For Input";
    private string leftGrip = "Waiting For Input";
    private string rightZone = "Waiting For Input";
    private string leftZone = "Waiting For Input";
    private string rightCast = "Waiting For Input";
    private string leftCast = "Waiting For Input";


    public void SetTextRight(string text)
    {
        if(text != null)
            rightGrip = text;
        else
            rightGrip = defaultText;

        SetText();
    }

    public void SetTextLeft(string text)
    {
        if (text != null)
            leftGrip = text;
        else
            rightGrip = defaultText;

        SetText();
    }

    public void SetZoneLeft(string text)
    {
        if (text != null)
            leftZone = text;
        else
            leftZone = defaultText;

        SetText();
    }

    public void SetZoneRight(string text)
    {
        if (text != null)
            rightZone = text;
        else
            rightZone = defaultText;

        SetText();
    }

    public void SetCastingStateLeft(string text)
    {
        leftCast = text;
    }

    public void SetCastingStateRight(string text)
    {
        rightCast = text;
    }

    // Use this for initialization
    void Start () {
        textInstance = Instantiate(textPrefab, transform.position + offset, transform.rotation, transform);
        SetText();
    }

    private void SetText()
    {
        textInstance.text = "Right Grip: " + rightGrip + "\nRight Zone: " + rightZone + "\nRight Cast: " + rightCast + "\n\nLeft Grip:" + leftGrip + "\nLeft Zone: " + leftZone + "\nLeft Cast: " + leftCast;
    }
}
