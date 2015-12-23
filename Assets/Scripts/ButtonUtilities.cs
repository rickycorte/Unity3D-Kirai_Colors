using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonUtilities : MonoBehaviour {

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
}
