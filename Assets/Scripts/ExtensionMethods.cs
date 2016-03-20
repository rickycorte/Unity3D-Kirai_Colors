/*
  Unity3D Kirai Colors

  Copyright (c) 2015-2016 RickyCoDev
  Licensed under Mit Licence
*/
using UnityEngine;
using System.Collections;

public static class ExtensionMethods {

    public static string ToHex(this Color color)
    {
        string hex = Mathf.RoundToInt(color.r * 255f).ToString("X2") + Mathf.RoundToInt(color.g * 255f).ToString("X2") + Mathf.RoundToInt(color.b * 255f).ToString("X2");
        //Debug.Log("Hex: " + hex);
        return hex;
    }
}
