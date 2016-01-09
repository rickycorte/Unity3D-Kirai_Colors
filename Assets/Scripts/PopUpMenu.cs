using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUpMenu : MonoBehaviour {

    public delegate void Action();

    Action PositiveClick;
    Action NegativeClick;

    [SerializeField]Text HeaderText;

    [SerializeField] Button PositiveButton;
    [SerializeField] Button NegativeButton;

    public void SetInfo(string message, Action PosAction)
    {
        HeaderText.text = message;
        PositiveClick = PosAction;
        //Time.timeScale = 0;
    }


    public void SetInfo(string message, Action PosAction, Action NegAction)
    {
        HeaderText.text = message;
        PositiveClick = PosAction;
        NegativeClick = NegAction;
        //Time.timeScale = 0;
    }

    void Start()
    {
        PositiveButton.onClick.AddListener(delegate { Positive_OnClick(); });
        NegativeButton.onClick.AddListener(delegate { Negative_OnClick(); });
    }

    void Positive_OnClick()
    {
        if(PositiveClick != null)
        PositiveClick();

        Close();

    }

    void Negative_OnClick()
    {
        if(NegativeClick != null)
        NegativeClick();

        Close();
    }


    void Close()
    {
        //Time.timeScale = 1;
        NegativeButton.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void CustomMessage(string message)
    {
        NegativeButton.gameObject.SetActive(false);
        HeaderText.text = message;
    }
}
