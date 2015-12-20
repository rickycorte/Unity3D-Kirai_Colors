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

    public void Quit()
    {
        Application.Quit();
    }
}
