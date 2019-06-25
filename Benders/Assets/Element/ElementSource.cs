using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSource : MonoBehaviour {

    public Element element;
    public int max;

    private int currentCount;
    private Color color;
    private Renderer m_renderer;

	// Use this for initialization
	void Start () {
        currentCount = max;
        color = element.GetColor();
        m_renderer = transform.gameObject.GetComponent<Renderer>();
        m_renderer.material.color = color;
	}
	
	// Update is called once per frame
	void Update () {
        float H, S, V, mod = (float)currentCount/(float)max;
        
        Color.RGBToHSV(color, out H, out S, out V);
        m_renderer.material.color = Color.HSVToRGB(H, S * mod,V);
    }

   public Element Drain()
    {
        Debug.Log("DRAIN");
        if(currentCount > 0)
        {
            currentCount--;
            return element;
        }
        return null;
    }

    public void ResetSourceCount()
    {
        currentCount = max;
    }
}
