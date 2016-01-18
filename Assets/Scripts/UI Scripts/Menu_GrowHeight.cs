using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UI_Scripts
{

    [RequireComponent(typeof(LayoutElement))]
    [RequireComponent(typeof(CanvasGroup))]
    public class Menu_GrowHeight : MonoBehaviour
    {
        Transform[] myContent;
        LayoutElement LayEl;
        CanvasGroup cvGroup;
        [SerializeField] float OpenedHeight = 220f;
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

            myContent = transform.GetComponentsInChildren<Transform>();
            SetContentActive(isOpen);
        }

        public void OpenMenu()
        {
           
            if(cr != null)
            StopCoroutine(cr);
            isOpen = true;
            SetContentActive(isOpen);
            cvGroup.interactable = true;
            cvGroup.blocksRaycasts = true;
            cr = StartCoroutine(SetMenuHeight(OpenedHeight));

            //Debug.Log("Opening Menu");

        }

        public void CloseMenu()
        {
            if(cr != null)
            StopCoroutine(cr);

            isOpen = false;
            cvGroup.interactable = false;
            cvGroup.blocksRaycasts = false;
            cr = StartCoroutine(SetMenuHeight(0));
            //Debug.Log("Closing Menu");


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
                        if (!isOpen)
                        {
                            SetContentActive(isOpen);
                        }
                       
                        //Debug.Log("Reached prefered height");
                        break;
                    }
                    yield return null;
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


        void SetContentActive(bool open)
        {
            for (int i = 0; i < myContent.Length; i++)
            {
                myContent[i].gameObject.SetActive(isOpen);
            }
        }

    }
}
