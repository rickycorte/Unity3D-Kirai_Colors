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

        [SerializeField] GameOverMenu gmOverMenu;

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
                    UpdateScoreText("Progress: " + score + "/" + TimeAttack_MaxScore);
                    break;
                default:
                    Debug.LogError("No implementation for that GameMode");
                    break;
            }

            //GetAllColors();


        }

        // Use this for initialization
        void Start() {

            Init();
            if (isStarted)
            {
                NewButtons();
            }

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

        //set color of all buttons and correct one 
        void SetUpButtonsColor(int correct_index, int correct_color_index)
        {
            for (int i = 0; i < GameButtons.Count; i++)
            {
                if (i != correct_index)
                {
                    int col_index;
                    do {
                        col_index = Random.Range(0, ColorExtension.colors.Length);
                    } while (col_index == correct_color_index);

                    Debug.Log("Setting color: " + ColorExtension.colors[col_index] + " to button: " + i);
                    GameButtons[i].SetProperties(false, ColorExtension.colors[col_index]);

                }
                else
                {
                    Debug.Log("Correct button is in pos: " + correct_index + " and it's color is: " + ColorExtension.colors[correct_color_index]);
                    GameButtons[i].SetProperties(true, ColorExtension.colors[correct_color_index]);
                    SetHeaderText(ColorExtension.colors[correct_color_index]);
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
            if (isStarted)
            {
                SetUpButtonsColor(Random.Range(0, GameButtons.Count), Random.Range(0, ColorExtension.colors.Length));
            }
        }


        public void addScore()
        {
            //TODO:calcolare punteggio in base a tempo       
            ScoreAdded.text = "+" + PointsToAdd;
            score += PointsToAdd;

        }

        //update score text 
        void UpdateScoreText(string text)
        {
            ScoreText.text = text;
        }

        //function to call in update delegate
        void TimeAttack_TimerAction()
        {
            timer += Time.deltaTime;
            TimeAttack_UpdateBarTimer();
        }

        //function to call when click on wrong button
        void TimeAttack_WrongClick()
        {
            timer += 10f;
        }

        //update barr fill and also scoretext
        void TimeAttack_UpdateBarPos()
        {
            bar.SetSliderPos(score);
            UpdateScoreText("Progress: " + score + "/" + TimeAttack_MaxScore);
            TimeAttack_CheckForEndGame();
        }
        //update timer inside bar with a readable time expr
        void TimeAttack_UpdateBarTimer()
        {
            System.TimeSpan time = System.TimeSpan.FromSeconds(timer);
            string timeString = string.Format("{0:D}:{1:D2}:{2:D1}", time.Minutes, time.Seconds, Mathf.RoundToInt(time.Milliseconds/100f));
            bar.UpdateText(timeString);
        }

        //prevent manager to execute button refresh or update actions
        void StopGame()
        {
            isStarted = false;
        }

        
        void TimeAttack_CheckForEndGame()
        {
            if (score >= TimeAttack_MaxScore)
            {
                TimeAttack_EndGame();
            }

        }


        void TimeAttack_EndGame()
        {
            StopGame();
            gmOverMenu.gameObject.SetActive(true);
            gmOverMenu.SetInfo(GameMode, timer);
        }



        void Update()
        {
            if(UpdateAction != null && isStarted)
            UpdateAction();
        }

    }

}
