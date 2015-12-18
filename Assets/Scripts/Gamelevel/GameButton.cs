using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Game
{
    public class GameButton : MonoBehaviour
    {

        Button btn;
        Image img;

        bool isRight = false;


        void Init()
        {
            btn = GetComponent<Button>();
            img = GetComponent<Image>();
            btn.onClick.AddListener(delegate { OnClick(); }); // add listener to button click. This allows the call of OnClick function
        }

        //*external call to set* button color and is is the correct one
        public void SetProperties(bool correct, Color btnCol)
        {
            img.color = btnCol;
            isRight = correct;
        }


        // Use this for initialization
        void Start()
        {
            Init();
        }

        //function colled when button is clicked
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
