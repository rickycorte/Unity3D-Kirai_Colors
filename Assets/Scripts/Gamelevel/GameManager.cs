using UnityEngine;
using System.Collections.Generic;


namespace Game
{
    public class GameManager : MonoBehaviour {

        bool isStarted = true;

        [SerializeField] int score = 0;
        [SerializeField] List<GameButton> GameButtons;
        ExtendedColor[] colors = new ExtendedColor[]
            { ColorExtension.red,ColorExtension.blue,ColorExtension.cyan,ColorExtension.gray,ColorExtension.green,
                ColorExtension.red,ColorExtension.white,ColorExtension.yellow
            };

        // Use this for initialization
        void Start() {

            if (isStarted)
            {
                SetUpButtonsColor(4, 1);
            }

        }


        void SetUpButtonsColor(int correct_index,int correct_color_index)
        {            
            for (int i = 0; i < GameButtons.Count; i++)
            {
                if (i != correct_index)
                {
                    int col_index;
                    do{
                        col_index = Random.Range(0, colors.Length);
                    } while (col_index == correct_color_index);

                    Debug.Log("Setting color: " + colors[col_index] + " to button: " + i);
                    GameButtons[i].SetProperties(false, colors[col_index]);

                }
                else
                {
                    Debug.Log("Correct button is in pos: " + correct_index + "ans it's color is: " + colors[correct_color_index]);
                    GameButtons[i].SetProperties(true, colors[correct_color_index]);
                }
            }
        }


    }
}
