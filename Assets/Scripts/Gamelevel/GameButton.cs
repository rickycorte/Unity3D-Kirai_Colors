using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Game
{
    public class GameButton : MonoBehaviour
    {

        Button btn;

        bool isRight = false;


        void Init()
        {
            btn = GetComponent<Button>();
            btn.onClick.AddListener(delegate { OnClick(); });
        }


        public void SetProperties(bool correct, Color btnCol)
        {
            btn.gameObject.GetComponent<Image>().color = btnCol;
            isRight = correct;
        }


        // Use this for initialization
        void Start()
        {

            Init();
        }


        void OnClick()
        {
            //Debug.Log("Click event");
            if (isRight)
            {
                References.evMaster.RightButtonClick();
            }
            else
            {
                References.evMaster.WrongButtonClick();
            }

        }
    }
}
