using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonUtilities : MonoBehaviour
{

    [SerializeField] PopUpMenu popUp;

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void LoadLevelByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadGameLevel()
    {
        LoadLevel("Game");
    }

    //save into playerprefs the selected mode
    public void SetGameMode(int gm)
    {
        PlayerPrefs.SetInt("GameMode", gm);
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        LoadLevel("MainMenu");
    }

    public void PopUpQuit()
    {
        popUp.gameObject.SetActive(true);
        popUp.SetInfo("Do you want to exit from the game?", Quit);
    }

    public void PopUpLoadMainMenu()
    {
        popUp.gameObject.SetActive(true);
        popUp.SetInfo("Do you want to go back to Main Menu?", LoadMainMenu);
    }

    public void FeedbBackUrl()
    {
        Application.OpenURL("https://docs.google.com/forms/d/1FQur65aY2v6UbyDhjdsgUaCG8wHeEReuqKHezffokao/viewform?usp=send_form");
    }

    public void RateApp()
    {
        //RateHandler.CallEventRateUs();
#if UNITY_WINRT_8_1
        Application.OpenURL("ms-windows-store:reviewapp?appid=46c470e1-a126-4138-bf14-1bbcd020eada");
#endif
#if UNITY_ANDROID
        Application.OpenURL("market://details?id=com.RickyIT.Tap_That");
#endif
    }

    public void Donate()
    {
        Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=6ZN83HH24U5RU");
    }

}
