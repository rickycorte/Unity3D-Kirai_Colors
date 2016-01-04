using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExpericePanel : MonoBehaviour {

    [SerializeField] Text ExpText;
    [SerializeField] Text LevelText;
    [SerializeField] Slider slide;
    [SerializeField] GameObject RankUpMessage;

    float lerp = 2f;
    float closeEnouth = 1f;
    // Use this for initialization

    public void UpdateExpPanel()
    {
        int expToNextLv = PlayerLevelManager.expToNextLevel - PlayerLevelManager.currentExp;
        ExpText.text = "> "+ expToNextLv.ToString();

        LevelText.text = "To level: " + (PlayerLevelManager.currentLevel + 1);
        slide.maxValue = PlayerLevelManager.expToNextLevel;
        Debug.Log("Slider: " + slide.value + " of " + slide.maxValue);
        StartCoroutine(BarLerp());
        if (PlayerLevelManager.isRankUp)
        {
            RankUpMessage.SetActive(true);
        }
    }

    bool LerpLuevelUpDone = false;

    IEnumerator BarLerp()
    {
        //Debug.Log("Curr exp:" + PlayerLevelManager.currentExp);
        while (true)
        {
            //Debug.Log("Animating");
            slide.value = Mathf.Lerp(slide.value, PlayerLevelManager.currentExp, lerp * Time.deltaTime);
            if (PlayerLevelManager.currentExp - slide.value <= closeEnouth)
            {
                Debug.Log("Animation done");
                break;
            }
            yield return null;
        }

    }
}
