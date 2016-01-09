using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace MainMenu
{
    public class ModeLocker : MonoBehaviour
    {

        [SerializeField] PopUpMenu ErrorMessage;
        [SerializeField] int UnlockLevel = 0;
        [SerializeField] Image ButtonIcon;
        [SerializeField] Sprite LockedIcon;

        // Use this for initialization
        void Start()
        {
            if (UnlockLevel > PlayerLevelManager.currentLevel)
            {
                Button btn;
                ButtonIcon.sprite = LockedIcon;
                btn = GetComponent<Button>();
                //disable all listners set into editor
                for (int i = 0; i < btn.onClick.GetPersistentEventCount(); i++)
                {
                    btn.onClick.SetPersistentListenerState(i, UnityEngine.Events.UnityEventCallState.Off);
                }

                btn.onClick.AddListener(delegate
                {
                    ErrorMessage.gameObject.SetActive(true);
                    ErrorMessage.CustomMessage("This mode is locked!\n You need to be at level " + UnlockLevel + " to unlock this.");
                });
            }
            else
            {
                Destroy(this);
            }


        }


    }
}
