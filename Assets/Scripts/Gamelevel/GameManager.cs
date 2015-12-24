using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


namespace Game
{
    public class GameManager : MonoBehaviour {

        public bool isTestMode = false;

        public enum GameModes {TimeAttack_Short,TimeAttack,TimeAttack_Long, Rush, Rush_Crazy, Rush_Insane }

        public GameModes GameMode;

        bool isStarted = true;


        [SerializeField] int score = 0;
        int TimeAttack_MaxScore = 25;
        int PointsToAdd = 0;

        [SerializeField] float timer = 0f;

        int Rush_MaxTimer = 5;

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
            //ev.OnRightButtonClick += addScore;
            
        }

        void OnDisable()
        {
            ev.OnRightButtonClick -= NewButtons;
            //ev.OnRightButtonClick -= addScore;
            //ev.OnWrongButtonClick -= TimeAttack_WrongClick;
            switch (GameMode)
            {
                case GameModes.TimeAttack_Short:
                    Rm_TimeAttack();
                    break;
                case GameModes.TimeAttack:
                    Rm_TimeAttack();
                    break;
                case GameModes.TimeAttack_Long:
                    Rm_TimeAttack();
                    break;
                case GameModes.Rush:
                    Rm_Rush();
                    break;     
            }
        }


        void Init()
        {
            if (!isTestMode)
            {
                GameMode = (GameModes)GetGamemodeFromDrive();
            }
            switch (GameMode)
            {
                case GameModes.TimeAttack_Short:
                    TimeAttack_MaxScore = 25;
                    SetUp_TimeAttack();
                    break;
                case GameModes.TimeAttack:
                    TimeAttack_MaxScore = 50;
                    SetUp_TimeAttack();
                    break;
                case GameModes.TimeAttack_Long:
                    TimeAttack_MaxScore = 100;
                    SetUp_TimeAttack();
                    break;
                case GameModes.Rush:
                    Rush_MaxTimer = 10;
                    PointsToAdd = 5;
                    SetUp_Rush();
                    break;
                case GameModes.Rush_Crazy:
                    Rush_MaxTimer = 6;
                    PointsToAdd = 10;
                    SetUp_Rush();
                    break;
                case GameModes.Rush_Insane:
                    Rush_MaxTimer = 3;
                    PointsToAdd = 20;
                    SetUp_Rush();
                    break;
                default:
                    Debug.LogError("No implementation for that GameMode");
                    break;
            }
        }


        int GetGamemodeFromDrive()
        {
            if (PlayerPrefs.HasKey("GameMode"))
                return PlayerPrefs.GetInt("GameMode");
            Debug.LogError("No Gamemode set!");
            return 0; // default gamemode
        }

        //set events and vars for time attack modes
        void SetUp_TimeAttack()
        {
            PointsToAdd = 1;
            UpdateAction += TimeAttack_TimerAction; // adds timer function  to update delegate
            ev.OnRightButtonClick += TimeAttack_addScore; // adds score before updating bar
            ev.OnRightButtonClick += TimeAttack_UpdateBarPos; // update the bar fill
            ev.OnWrongButtonClick += TimeAttack_WrongClick; // sets the action for wrong click
            bar.SetSliderMaxValue(TimeAttack_MaxScore);
            UpdateScoreText("Progress: " + score + "/" + TimeAttack_MaxScore);
        }

        void Rm_TimeAttack()
        {
            UpdateAction -= TimeAttack_TimerAction;
            ev.OnRightButtonClick -= TimeAttack_UpdateBarPos;
            ev.OnWrongButtonClick -= TimeAttack_WrongClick;
            ev.OnRightButtonClick -= TimeAttack_addScore;
        }

        //setup Rush Gamemodes
        void SetUp_Rush()
        {
            timer = Rush_MaxTimer;
            bar.InvereAndSet(Rush_MaxTimer);
            UpdateAction += Rush_UpdateAction;
            ev.OnRightButtonClick += Rush_RightClick;
            ev.OnWrongButtonClick += Rush_WrongClick;
        }

        void Rm_Rush()
        {
            UpdateAction -= Rush_UpdateAction;
            ev.OnRightButtonClick -= Rush_RightClick;
            ev.OnWrongButtonClick -= Rush_WrongClick;
        }

        // Use this for initialization
        void Start() {

            Init();
            if (isStarted)
            {
                NewButtons();
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

        //prevent manager to execute button refresh or update actions
        void StopGame()
        {
            isStarted = false;
        }



        public void TimeAttack_addScore()
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
            //gmOverMenu.SetInfo(GameMode, timer);
            gmOverMenu.TimeAttack_InfoPeset(timer);
        }



        void Rush_UpdateAction()
        {
            timer -= Time.deltaTime;
            TimeAttack_UpdateBarTimer();
            Rush_UpdateBar();
            if (timer <= 0)
            {
                Rush_EndGame("TimeOut");
            }
        }

        void Rush_WrongClick()
        {
            Rush_EndGame("Wrong Color");
        }

        void Rush_EndGame(string motivation)
        {
            StopGame();
            gmOverMenu.gameObject.SetActive(true);
            gmOverMenu.Rush_InfoPreset(score, motivation);
        }

        void Rush_RightClick()
        {
            Rush_AddScore();
            timer = Rush_MaxTimer;
            Rush_UpdateScoreText();
        }

        void Rush_UpdateScoreText()
        {
            UpdateScoreText("Score: " + score);
        }

        void Rush_UpdateBar()
        {
            bar.SetSliderPos(timer);
        }

        void Rush_AddScore()
        {
            int scoreToAdd = Mathf.RoundToInt(CalculateScoreToAdd(timer, PointsToAdd, Rush_MaxTimer));
            Debug.Log("Score to add: " + CalculateScoreToAdd(timer, PointsToAdd, Rush_MaxTimer));
            ScoreAdded.text = "+" + scoreToAdd;
            score += scoreToAdd;
            //Rush_UpdateScoreText();
        }


        float CalculateScoreToAdd(float tm,float ptMax,float tmMax) // riferimento alle foto allegates
        {
            tm = tmMax - tm; // correzione tempo decrescente
           // Debug.Log("Enter with: " + tm + " " + ptMax + " " + tmMax);
            float res = (ptMax - 1) / (tmMax * tmMax) * (tm * tm); // ax^2
            //Debug.Log(res.ToString());
            res -= 2 * ((ptMax - 1) / tmMax) * tm;
            //Debug.Log(res.ToString());
            res += ptMax;
            //Debug.Log(res.ToString());
            return res;
        }

        void Update()
        {
            if(UpdateAction != null && isStarted)
            UpdateAction();
        }

    }

}
