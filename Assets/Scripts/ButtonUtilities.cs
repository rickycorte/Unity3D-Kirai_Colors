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
        popUp.SetInfo("Are you sure that to go back to Main Menu?", LoadMainMenu);
    }

}
