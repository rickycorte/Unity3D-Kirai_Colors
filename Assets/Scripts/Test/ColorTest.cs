using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Test
{
    public class ColorTest : MonoBehaviour
    {


        float timer = 2f;
        const float MaxTimer = 2;

        [SerializeField] Text HeadText;
        [SerializeField] Image img;

        int colorIndex = 0;


        void Update()
        {
            timer += Time.deltaTime;
            if (timer > MaxTimer )
            {
                if (colorIndex < ColorExtension.colors.Length)
                {
                    NextColor();
                    timer = 0;
                }
                else
                {
                    //HeadText.text = "No more colors";
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }


        void NextColor()
        {
            img.color = ColorExtension.colors[colorIndex];
            HeadText.text = ColorExtension.colors[colorIndex]+"\n"+(colorIndex+1)+"/"+ColorExtension.colors.Length;
            colorIndex++;
        }

        //use reflection to get all colors in ColorExtension Class
        //void GetAllColors()
        //{

        //    foreach (var prop in typeof(ColorExtension).GetFields())
        //    {
        //        ExtendedColor col = (ExtendedColor)prop.GetValue(null);
        //        //Debug.Log(col.name);
        //        colors.Add(col);
        //    }
        //    Debug.Log("Found " + colors.Count + " colors");
        //}

    }
}
