using UnityEngine;
using System.Collections.Generic;

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

    public static ExtendedColor pink = new ExtendedColor("Pink", 0xff,0xc0,0xcb);

    public static ExtendedColor orange = new ExtendedColor("Orange", 0xff, 0xa5, 0x00);

    public static ExtendedColor brown = new ExtendedColor("Brown", 0x96,0x4b,0x00);

    //public static ExtendedColor lightbrown = new ExtendedColor("Light Brown", 0xde, 0xb8, 0x87);

    public static ExtendedColor amber = new ExtendedColor("Amber", 0xff, 0xbf, 0x00);

    public static ExtendedColor olive = new ExtendedColor("Olive Green", 0xa2, 0xcd, 0x5a);

    public static ExtendedColor darkorange = new ExtendedColor("Dark Orange", 0xee, 0x76, 0x00);

    public static ExtendedColor salmon = new ExtendedColor("Salmon", 0xe9, 0x67, 0x7a);

    public static ExtendedColor deepskyblue = new ExtendedColor("Deep Sky Blue", 0x00, 0x9a, 0xcd);

    public static ExtendedColor indianred = new ExtendedColor("Indian Red", 0xcd, 0x55, 0x55);

    public static ExtendedColor fuchsia = new ExtendedColor("Fuchsia", 0xfb, 0x00, 0xfb);

    public static ExtendedColor violetred = new ExtendedColor("Violet Red", 0xc7, 0x15, 0x85);

    public static ExtendedColor palegreen = new ExtendedColor("Pale Green", 0x9a, 0xff, 0x9a);

    public static ExtendedColor bordeaux = new ExtendedColor("Bordeaux", 0x5c, 0x01, 0x20);

    public static ExtendedColor canary = new ExtendedColor("Canary", 0xf3, 0xfb, 0x62);

    //public static ExtendedColor casper = new ExtendedColor("Casper", 0xad, 0xbe, 0xd1);

    public static ExtendedColor chocolate = new ExtendedColor("Chocolate", 0x55, 0x28, 0x0C);

    public static ExtendedColor emerald = new ExtendedColor("Emerald", 0x50, 0xc8, 0x78);

    //public static ExtendedColor geraldine = new ExtendedColor("Geraldine", 0xfb, 0x89, 0x89);

    //public static ExtendedColor goldenglow = new ExtendedColor("Golden Glow", 0xfd, 0xe2, 0x95);

    public static ExtendedColor gulfblue = new ExtendedColor("Gulf Blue", 0x05, 0x16, 0x57);

    //public static ExtendedColor heliotrope = new ExtendedColor("Heliotrope", 0xdf, 0x73, 0xff);

    //public static ExtendedColor fhippieblue = new ExtendedColor("Hippie Blue", 0x58, 0x9a, 0xaf);

    //public static ExtendedColor hitpink = new ExtendedColor("Hit Pink", 0xff, 0xab, 0x81);

    //public static ExtendedColor iron = new ExtendedColor("Iron", 0xd4, 0xd7, 0xd9);

    //public static ExtendedColor kimberly= new ExtendedColor("Kimberly", 0x73, 0x6c, 0x9f);

    public static ExtendedColor limedoak = new ExtendedColor("Limed Oak", 0xac, 0x8a, 0x56);

    //public static ExtendedColor lola = new ExtendedColor("Lola", 0xdf, 0xcf, 0xdb);

    public static ExtendedColor malibu = new ExtendedColor("Malibu", 0x7d, 0xc8, 0xf7);

    public static ExtendedColor melanzane = new ExtendedColor("Melanzane", 0x30, 0x05, 0x29);

    //public static ExtendedColor mimosa = new ExtendedColor("Mimosa", 0xf8, 0xfd, 0xd3);

    //public static ExtendedColor fountainblue = new ExtendedColor("Fountain Blue", 0x56, 0xb4, 0xbe);

    //public static ExtendedColor mintjulep = new ExtendedColor("Mint Julep", 0xf1, 0xee, 0xc1);

    //public static ExtendedColor mistgray = new ExtendedColor("Mist Gray", 0xc4, 0xc4, 0xbc);

   // public static ExtendedColor mojo = new ExtendedColor("Mojo", 0xc0, 0x47, 0x37);

    //public static ExtendedColor mossgreen = new ExtendedColor("Moss Green", 0xad, 0xdf, 0xad);

    public static ExtendedColor navyblue = new ExtendedColor("Navy Blue", 0x00, 0x00, 0x80);

    public static ExtendedColor ochre = new ExtendedColor("Ochre", 0xcc, 0x77, 0x22);

    //public static ExtendedColor onahau = new ExtendedColor("Onahau", 0xcd, 0xf4, 0xff);

    //public static ExtendedColor oxley = new ExtendedColor("Oxley", 0x77, 0x9e, 0x86);

    public static ExtendedColor aquagreen = new ExtendedColor("Aqua Green", 0x23, 0xab, 0x9a);

    public static ExtendedColor paprika = new ExtendedColor("Paprika", 0x8d, 0x02, 0x26);


    public static ExtendedColor[] colors = new ExtendedColor[] {
        red,blue,black,cyan,gray,green,white,yellow,pink,orange,brown,/*lightbrown,*/amber,olive,darkorange,salmon,deepskyblue,indianred,fuchsia,
          violetred,palegreen,bordeaux,canary,/*casper,*/chocolate,emerald,/*geraldine,goldenglow,*/gulfblue,/*heliotrope,fhippieblue,hitpink,iron,
          kimberly,*/limedoak,/*lola,*/malibu,melanzane,/*mimosa/fountainblue,mintjulep,mistgray,mojo,mossgreen,*/navyblue,ochre,/*onahau,oxley,*/aquagreen,paprika
    };

}
