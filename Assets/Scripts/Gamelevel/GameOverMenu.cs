using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Game
{
    public class GameOverMenu : MonoBehaviour {

        [SerializeField] Text HeaderText;
        [SerializeField] Text ScoreHeaderText;
        [SerializeField] Text ScoreText;


        public void SetInfo(GameManager.GameModes gameMode, float score)
        {
            switch (gameMode)
            {
                case GameManager.GameModes.Time_Attack:
                    HeaderText.text = "Time Attack";
                    ScoreHeaderText.text = "Your time: ";
                    System.TimeSpan time = System.TimeSpan.FromSeconds(score); // used to print a readable time expression
                    string timestring = string.Format("{0:D}:{1:D2}:{2:D1}", time.Minutes, time.Seconds, Mathf.RoundToInt(time.Milliseconds / 100f));
                    ScoreText.text = timestring;
                    break;
                default:
                    Debug.LogError("Ni implementation found");
                    break;
            }
        }

        //TODO: generare link per lo share

    }
}
