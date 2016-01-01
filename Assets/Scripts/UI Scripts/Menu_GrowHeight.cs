using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UI_Scripts
{

    [RequireComponent(typeof(LayoutElement))]
    [RequireComponent(typeof(CanvasGroup))]
    public class Menu_GrowHeight : MonoBehaviour
    {

        LayoutElement LayEl;
        CanvasGroup cvGroup;
        float OpenedHeight = 220f;
        float closeEnouth = 1f;
        float Lerp = 7f;

        Coroutine cr;


        bool isOpen = true;

        // Use this for initialization
        void Start()
        {
            LayEl = GetComponent<LayoutElement>();
            cvGroup = GetComponent<CanvasGroup>();
            if (LayEl.preferredHeight == OpenedHeight)
                isOpen = true;
            else
                isOpen = false;

            cvGroup.interactable = isOpen;
            cvGroup.blocksRaycasts = isOpen;
               
        }

        public void OpenMenu()
        {
            if(cr != null)
            StopCoroutine(cr);

            isOpen = true;
            cvGroup.interactable = true;
            cvGroup.blocksRaycasts = true;
            cr = StartCoroutine(SetMenuHeight(OpenedHeight));
            Debug.Log("Opening " + gameObject.name);

        }

        public void CloseMenu()
        {
            if(cr != null)
            StopCoroutine(cr);

            isOpen = false;
            cvGroup.interactable = false;
            cvGroup.blocksRaycasts = false;
            cr = StartCoroutine(SetMenuHeight(0));
            Debug.Log("Closing " + gameObject.name);

        }

        //height animation
        IEnumerator SetMenuHeight(float TargetHeight)
        {
            if (TargetHeight != LayEl.preferredHeight)
            {
                while (true)
                {
                    LayEl.preferredHeight = Mathf.Lerp(LayEl.preferredHeight, TargetHeight, Time.deltaTime * Lerp);
                    if ((LayEl.preferredHeight < closeEnouth && !isOpen) ||( LayEl.preferredHeight > TargetHeight - closeEnouth && isOpen ))
                    {
                        LayEl.preferredHeight = TargetHeight;
                        Debug.Log("Reached prefered height");
                        break;
                    }
                    yield return new WaitForEndOfFrame();
                }
            }

            yield return null;
        }


        public void Toggle()
        {
            if (!isOpen)
                OpenMenu();
            else
                CloseMenu();
        }


    }
}
