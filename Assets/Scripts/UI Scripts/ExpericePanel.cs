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
        if (PlayerLevelManager.currentLevel != PlayerLevelManager.MaxLevel)
        {
            int expToNextLv = PlayerLevelManager.expToNextLevel - PlayerLevelManager.currentExp;
            ExpText.text = "> " + expToNextLv.ToString();
            LevelText.text = "To level: " + (PlayerLevelManager.currentLevel + 1);
        }
        else
        {
            LevelText.text = "Max Level!";
            ExpText.gameObject.SetActive(false);
        }
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
            if (PlayerLevelManager.currentLevel != PlayerLevelManager.MaxLevel)
            {
                slide.value = Mathf.Lerp(slide.value, PlayerLevelManager.currentExp, lerp * Time.deltaTime);
            }
            else
            {
                slide.value = Mathf.Lerp(slide.value, slide.maxValue, lerp * Time.deltaTime);
            }

            if (PlayerLevelManager.currentExp - slide.value <= closeEnouth)
            {
                slide.value = PlayerLevelManager.currentLevel != PlayerLevelManager.MaxLevel ? PlayerLevelManager.currentExp : slide.maxValue;
                Debug.Log("Animation done");
                break;
            }
            yield return null;
        }

    }
}
