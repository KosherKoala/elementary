using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class ColorPicker {

    private static Color[]  tempSpectrum = { Color.blue, new Color(.3f, .8f, 1f), new Color(.56f, .91f, 11), Color.white, Color.yellow, new Color(1f, .37f, 0f), Color.red};

    public static Color[] GetColorDuo(float temperature)
    {
        return GetTemperatureColors(temperature);
    }

    private static Color[] GetTemperatureColors(float temperature)
    {
        Color[] colors = new Color[2];
        float scaledTemp = (temperature + 1f) * 3;

        colors[0] = tempSpectrum[(int)Math.Floor(scaledTemp)];
        colors[1] = tempSpectrum[(int)Math.Ceiling(scaledTemp)];

        return colors;
    }

}
