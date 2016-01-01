using UnityEngine;
using System.Collections;
namespace UI_Scripts
{
    public class MenuManager : MonoBehaviour {

        GameObject openedMenu;

        public void OpenMenu(GameObject menuToOpen)
        {
            if (openedMenu == menuToOpen)
            {
                CloseMenu(menuToOpen);
                return;
            }

            if (openedMenu != null)
            {
                if (openedMenu.GetComponent<Menu_GrowHeight>())
                {
                    openedMenu.GetComponent<Menu_GrowHeight>().CloseMenu();
                }
            }

            if (menuToOpen.GetComponent<Menu_GrowHeight>())
            {
                menuToOpen.GetComponent<Menu_GrowHeight>().OpenMenu();
            }

            openedMenu = menuToOpen;
    }

        public void CloseMenu(GameObject menuToClose)
        {
            if (menuToClose.GetComponent<Menu_GrowHeight>())
            {
                menuToClose.GetComponent<Menu_GrowHeight>().Toggle();
            }
        }
    }
}
