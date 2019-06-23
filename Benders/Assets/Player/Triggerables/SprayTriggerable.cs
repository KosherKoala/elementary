using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayTriggerable : MonoBehaviour {

    public ParticleSystem systemPrefab;
    public Transform emissionPoint;
    public Color startColor;

    private ParticleSystem system;
    private bool triggered = false;

    public void Initialize()
    {
    }
   

    public void Trigger(Element element)
    {
        triggered = true;
        ParticleSystem.MainModule newMain = systemPrefab.main;

        Gradient gradient = new Gradient();
        GradientColorKey[] colorKey;
        GradientAlphaKey[] alphaKey;
        Color[] elementColors = ColorPicker.GetColorDuo(element.eTemperature);


        // Populate the color keys at the relative time 0 and 1 (0 and 100%)
        colorKey = new GradientColorKey[2];
        colorKey[0].color = elementColors[0];
        colorKey[0].time = 0.0f;
        colorKey[1].color = elementColors[1];
        colorKey[1].time = 1.0f;

        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);

        var randomColors = new ParticleSystem.MinMaxGradient(gradient);
        randomColors.mode = ParticleSystemGradientMode.RandomColor;
        newMain.startColor = randomColors;
        
        system = Instantiate(systemPrefab, emissionPoint);
        system.Play();
    }

    public void Cancel()
    {
        triggered = false;
        system.Stop();
        Destroy(system);
    }

    public bool IsTriggered()
    {
        return triggered;
    }
}
