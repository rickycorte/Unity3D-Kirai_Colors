using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Game
{
    public class GameOverMenu : MonoBehaviour {

        [SerializeField] Text HeaderText;
        [SerializeField] Text ScoreHeaderText;
        [SerializeField] Text ScoreText;
        [SerializeField] ExpericePanel expPanel;

        //public void SetInfo(GameManager.GameModes gameMode, float score)
        //{
        //    switch (gameMode)
        //    {
        //        case GameManager.GameModes.TimeAttack_Short:
        //            TimeAttack_InfoPeset(score);
        //            break;
        //        case GameManager.GameModes.TimeAttack:
        //            TimeAttack_InfoPeset(score);
        //            break;
        //        case GameManager.GameModes.TimeAttack_Long:
        //            TimeAttack_InfoPeset(score);
        //            break;
        //        case GameManager.GameModes.Rush:
        //            Rush_InfoPreset()
        //        default:
        //            Debug.LogError("No implementation found");
        //            break;
        //    }
        //}

        public void TimeAttack_InfoPeset(float score)
        {
            HeaderText.text = "Time Attack";
            ScoreHeaderText.text = "Your time: ";
            System.TimeSpan time = System.TimeSpan.FromSeconds(score); // used to print a readable time expression
            string timestring = string.Format("{0:D}:{1:D2}:{2:D1}", time.Minutes, time.Seconds, Mathf.RoundToInt(time.Milliseconds / 100f));
            ScoreText.text = timestring;
            expPanel.UpdateExpPanel();
        }

        public void Rush_InfoPreset(float score, string EndGameCause)
        {
            HeaderText.text = "Rush: "+EndGameCause;
            ScoreHeaderText.text = "Your Score: ";
            ScoreText.text = score.ToString();
            expPanel.UpdateExpPanel();
        }


        //TODO: generare link per lo share

    }
}
