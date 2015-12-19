using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


namespace Game
{
    public class GameManager : MonoBehaviour {

        public enum GameModes {Time_Attack, Rush }

        public GameModes GameMode;

        bool isStarted = true;


        [SerializeField] int score = 0;
        const int TimeAttack_MaxScore = 25;
        int PointsToAdd = 0;

        [SerializeField] float timer = 0f;

        [SerializeField] Text HeaderText; // text displayed on top 
        [SerializeField] Text ScoreText;
        [SerializeField] Text ScoreAdded;

        [SerializeField] List<GameButton> GameButtons; // list of 9 buttons references

        [SerializeField] CustomSlider bar;

        ExtendedColor[] colors = new ExtendedColor[]
            { ColorExtension.red,ColorExtension.blue,ColorExtension.cyan,ColorExtension.gray,ColorExtension.green,
                ColorExtension.black,ColorExtension.white,ColorExtension.yellow
            }; // all color list

        delegate void BaseAction(); 

        BaseAction UpdateAction;//function to rely with different timer uses

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
            //ev.OnWrongButtonClick -= TimeAttack_WrongClick;
            switch (GameMode)
            {
                case GameModes.Time_Attack:
                    UpdateAction -= TimeAttack_TimerAction; // adds timer function  to update delegate
                    ev.OnRightButtonClick -= TimeAttack_UpdateBarPos; // update the bar fill
                    ev.OnWrongButtonClick -= TimeAttack_WrongClick; // sets the action for wrong click
                    break;            
            }
        }

        void Init()
        {
            switch (GameMode)
            {
                case GameModes.Time_Attack:
                    PointsToAdd = 1;
                    UpdateAction += TimeAttack_TimerAction; // adds timer function  to update delegate
                    ev.OnRightButtonClick += TimeAttack_UpdateBarPos; // update the bar fill
                    ev.OnWrongButtonClick += TimeAttack_WrongClick; // sets the action for wrong click
                    bar.SetSliderMaxValue(TimeAttack_MaxScore);
                    break;
                default:
                    Debug.LogError("No implementation for that GameMode");
                    break;
            }
        }

        // Use this for initialization
        void Start() {

            Init();
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
            ScoreAdded.text = "+" + PointsToAdd;
            score += PointsToAdd;
            ScoreText.text = "Score: " + score;
        }


        void TimeAttack_TimerAction()
        {
            timer += Time.deltaTime;
            TimeAttack_UpdateBarTimer();
        }

        void TimeAttack_WrongClick()
        {
            timer += 10f;
        }

        void TimeAttack_UpdateBarPos()
        {
            bar.SetSliderPos(score);
        }

        void TimeAttack_UpdateBarTimer()
        {
            System.TimeSpan time = System.TimeSpan.FromSeconds(timer);
            string timeString = string.Format("{0:D}:{1:D2}:{2:D1}", time.Minutes, time.Seconds, Mathf.RoundToInt(time.Milliseconds/100f));
            bar.UpdateText(timeString);
        }


        void Update()
        {
            if(UpdateAction != null)
            UpdateAction();
        }

    }

}
