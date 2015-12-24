using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Game
{
    public class CustomSlider : MonoBehaviour
    {
        public Slider slider;
        public Text HoverText;

        //update slider hovertext
        public void UpdateText(string text)
        {
            HoverText.text = text;
        }

        //set the slider value
        public void SetSliderPos(float newPos)
        {
            slider.value = newPos;
        }

        //add val to slider value
        public void AddToSliderPos(float val)
        {
            slider.value += val;
        }

        public void SetSliderMaxValue(float val)
        {
            slider.maxValue = val;
        }

        //fill the bar and set the opposite fill direction
        public void Inverse()
        {
            slider.value = slider.maxValue;
            //slider.direction = Slider.Direction.RightToLeft;
        }

        public void InvereAndSet(float maxVal)
        {
            SetSliderMaxValue(maxVal);
            Inverse();
        }

    }
}
