using UnityEngine;
using System.Collections;

//class that contains only a list of static colors to use
public class ColorExtension : MonoBehaviour {

    public static ExtendedColor red = new ExtendedColor("Red", Color.red);

    public static ExtendedColor blue = new ExtendedColor("Blue", Color.blue);

    public static ExtendedColor black = new ExtendedColor("Black", Color.black);

    public static ExtendedColor cyan = new ExtendedColor("Cyan", Color.cyan);

    public static ExtendedColor gray = new ExtendedColor("Gray", Color.gray);

    public static ExtendedColor green = new ExtendedColor("Green", Color.green);

    public static ExtendedColor white = new ExtendedColor("White", Color.white);

    public static ExtendedColor yellow = new ExtendedColor("Yellow", Color.yellow);
}
