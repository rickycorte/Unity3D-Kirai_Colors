using UnityEngine;
using System.Collections;

public class AutoQualitySettings : MonoBehaviour {

    float fps =0f;
    float fps_count = 0f;
    float fps_refreshRate = 4f;
    float fps_delta;
    float timer=0f;
    float Max_Timer = 1f;

    float q_timer = 0f;

    [SerializeField] bool drawfps = true;
    string version = "Alpha 0.5";


    GUIStyle style = new GUIStyle();

    GUIStyle WarningStyle = new GUIStyle();

    void Start()
    {
        WarningStyle.fontSize = 16;
        WarningStyle.normal.textColor = Color.yellow;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        CalculateFps();
        UpdateFpsDrawColor();

        if (fps > 40)
            q_timer += Time.deltaTime;
        else
            q_timer = 0;

        if (timer > Max_Timer)
        {
            SetQualityLevelForFps();
            timer = 0;
        }
    }


    void OnGUI()
    {
        if (drawfps)
        {
            if (fps < 999)
                GUI.Label(new Rect(10, 50, 100, 20), "FPS: " + fps + " - Quality: " + QualitySettings.GetQualityLevel()+"\n"+version, style);
            else
                GUI.Label(new Rect(10, 50, 100, 20), "FPS: 999+ - Quality: " + QualitySettings.GetQualityLevel() + "\n" + version, style);
        }

    }

    /// <summary>
    /// calcola gli fps
    /// </summary>
    void CalculateFps()
    {
        fps_count++;
        fps_delta += Time.deltaTime;

        if (fps_delta > 1 / fps_refreshRate)
        {
            fps = fps_count / fps_delta;
            fps_count = 0;
            fps_delta = 0;
        }
    }

    /// <summary>
    /// select color based on  fps counter
    /// </summary>
    void UpdateFpsDrawColor()
    {
        if (drawfps)
        {

            if (fps < 20)
                style.normal.textColor = Color.red;
            if (fps >= 20 && fps <= 30)
                style.normal.textColor = Color.yellow;
            if (fps > 30)
                style.normal.textColor = Color.green;
        }
    }


    void SetQualityLevelForFps()
    {
        if (fps > 40 && q_timer > 2f)
        {
            QualitySettings.IncreaseLevel(false);
            q_timer = 0;

        }

        if (fps < 21)
        {
            QualitySettings.DecreaseLevel(false);
        }
    }

    public void DrawFps(bool value)
    {
        drawfps = value;
    }
}
