using UnityEngine;
using System.Collections;

namespace Game
{
    public class GameMode : MonoBehaviour
    {
        public enum Type { TimeAttack_Short, TimeAttack, TimeAttack_Long, Rush, Rush_Crazy, Rush_Insane }

        public Type Gamemode;

        public bool isStarted = false;

        [SerializeField]protected int score =0;

        protected int PointsToAdd = 0;
        [SerializeField] protected float timer = 0f;

        protected EventMaster ev;
        protected References _ref;

        protected AudioSource music;

        protected virtual void OnEnable()
        {          
            ev = References.evMaster;
            _ref = GetComponent<References>();
            music = GetComponent<AudioSource>();
        }

        protected virtual void OnDisable()
        {
            ev.OnRightButtonClick -= NewButtons;          
        }

        protected virtual void Init()
        {
            ev.OnRightButtonClick += NewButtons;
        }

        // Use this for initialization
        protected virtual void StartGame()
        {
            Debug.Log("Gamemode Start");
            Init();
            isStarted = true;
            NewButtons();
        }


        public virtual void SetGameMode(Type gm)
        {
            Debug.Log("Trying to set gm to: " + gm.ToString());
            StartGame();
        }

        //set color of all buttons and correct one
        void SetUpButtonsColor(int correct_index, int correct_color_index)
        {
            for (int i = 0; i < _ref.GameButtons.Count; i++)
            {
                if (i != correct_index)
                {
                    int col_index;
                    do
                    {
                        col_index = Random.Range(0, ColorExtension.colors.Length);
                    } while (col_index == correct_color_index);

                    //Debug.Log("Setting color: " + ColorExtension.colors[col_index] + " to button: " + i);
                    _ref.GameButtons[i].SetProperties(false, ColorExtension.colors[col_index]);
                }
                else
                {
                    //Debug.Log("Correct button is in pos: " + correct_index + " and it's color is: " + ColorExtension.colors[correct_color_index]);
                    _ref.GameButtons[i].SetProperties(true, ColorExtension.colors[correct_color_index]);
                    SetHeaderText(ColorExtension.colors[correct_color_index]);
                }
            }
        }

        //set header text
        void SetHeaderText(ExtendedColor col)
        {
            _ref.HeaderText.text = "Tap the <b><color=#"+col.color.ToHex()+"ff>" + col.name + "</color></b> quare!";
        }

        //refresh the buttons
        public virtual void NewButtons()
        {
            if (isStarted)
            {
                SetUpButtonsColor(Random.Range(0, _ref.GameButtons.Count), Random.Range(0, ColorExtension.colors.Length));
            }
        }

        //prevent manager to execute button refresh or update actions
        protected void StopGame()
        {
            isStarted = false;
            _ref.GameView.SetActive(false);
        }

        protected void UpdateScoreText(string text)
        {
            _ref.ScoreText.text = text;
        }


        protected void UpdateBarTimer()
        {
            System.TimeSpan time = System.TimeSpan.FromSeconds(timer);
            string timeString = string.Format("{0:D}:{1:D2}:{2:D1}", time.Minutes, time.Seconds, Mathf.RoundToInt(time.Milliseconds / 100f));
            _ref.bar.UpdateText(timeString);
        }

    }
}
