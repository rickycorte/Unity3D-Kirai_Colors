using UnityEngine;
using System.Collections;

//basic unity color that include also a name
public class ExtendedColor
{
    public Color color;
    public string name;
 
    public ExtendedColor(string Name, Color cl)
    {
        color = cl;
        name = Name;
    }

    public ExtendedColor(string Name, float r, float g, float b, float a)
    {
        color = new Color(r / 255f, g / 255f, b / 255f, a / 255);
        name = Name;
    }

    //alpha is set to 1
    public ExtendedColor(string Name, float r, float g, float b)
    {
        color = new Color(r / 255f, g / 255f, b / 255f, 1f);
        name = Name;
    }

    public static implicit operator string(ExtendedColor c)
    {
        return c.name;
    }

    public static implicit operator Color(ExtendedColor c)
    {
        return c.color;
    }
}
