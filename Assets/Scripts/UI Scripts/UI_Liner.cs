using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace UI_Scripts
{
#if UNITY_EDITOR
    [ExecuteInEditMode]
#endif
    public class UI_Liner : MonoBehaviour
    {
        [SerializeField] List<RectTransform> LineItems;

        float x;

        // Use this for initialization
        void Start()
        {
            Resize();
        }

        void Resize()
        {
            x = Screen.width / LineItems.Count;
            for (int i = 0; i < LineItems.Count; i++)
            {
                Vector3 pos = LineItems[i].offsetMin;
                pos.x = (x * i);
                LineItems[i].offsetMin = pos;
                pos = LineItems[i].offsetMax;
                pos.x = -x * (LineItems.Count - i - 1);
                LineItems[i].offsetMax = pos;

            }
        }

#if UNITY_EDITOR
        void Update()
        {
            Resize();          
        }
#endif

    }
}
