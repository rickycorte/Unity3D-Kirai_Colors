using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


namespace Game
{
    public class GameManager : MonoBehaviour {

        bool isStarted = true;

        [SerializeField] int score = 0;

        [SerializeField] Text HeaderText; // text displayed on top 
        [SerializeField] Text ScoreText;
        [SerializeField] Text ScoreAdded;

        [SerializeField] List<GameButton> GameButtons; // list of 9 buttons references

        ExtendedColor[] colors = new ExtendedColor[]
            { ColorExtension.red,ColorExtension.blue,ColorExtension.cyan,ColorExtension.gray,ColorExtension.green,
                ColorExtension.black,ColorExtension.white,ColorExtension.yellow
            }; // all color list

        EventMaster ev;

        void OnEnable()
        {
            ev = References.evMaster;
            ev.OnRightButtonClick += NewButtons; //TODO: versione temporanea 
            ev.OnRightButtonClick += addScore;
        }

        void OnDisable()
        {
            ev.OnRightButtonClick -= NewButtons;
            ev.OnRightButtonClick -= addScore;
        }

        // Use this for initialization
        void Start() {

            if (isStarted)
            {
                SetUpButtonsColor(Random.Range(0,GameButtons.Count), Random.Range(0,colors.Length));
            }

        }

        //set color of all buttons and correct one 
        void SetUpButtonsColor(int correct_index, int correct_color_index)
        {
            for (int i = 0; i < GameButtons.Count; i++)
            {
                if (i != correct_index)
                {
                    int col_index;
                    do {
                        col_index = Random.Range(0, colors.Length);
                    } while (col_index == correct_color_index);

                    Debug.Log("Setting color: " + colors[col_index] + " to button: " + i);
                    GameButtons[i].SetProperties(false, colors[col_index]);

                }
                else
                {
                    Debug.Log("Correct button is in pos: " + correct_index + " and it's color is: " + colors[correct_color_index]);
                    GameButtons[i].SetProperties(true, colors[correct_color_index]);
                    SetHeaderText(colors[correct_color_index]);
                }
            }
        }

        //set header text
        void SetHeaderText(string BtnToClick)
        {
            HeaderText.text = "Tap the " + BtnToClick + " button!";
        }

        //refresh the buttons
        public void NewButtons()
        {
            SetUpButtonsColor(Random.Range(0, GameButtons.Count), Random.Range(0, colors.Length));
        }

        public void addScore()
        {
            //TODO:calcolare punteggio in base a tempo
            int points = 10;
            ScoreAdded.text = "+" + points;
            score += points;
            ScoreText.text = "Score: " + score;
        }
    }
}
