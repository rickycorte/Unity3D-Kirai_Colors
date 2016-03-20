/*
  Unity3D Kirai Colors

  Copyright (c) 2015-2016 RickyCoDev
  Licensed under Mit Licence
*/
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
                openedMenu.GetComponent<Menu_GrowHeight>().CloseMenu();
            }

            menuToOpen.GetComponent<Menu_GrowHeight>().OpenMenu();

            openedMenu = menuToOpen;
    }

        void CloseMenu(GameObject menuToClose)
        {
                menuToClose.GetComponent<Menu_GrowHeight>().Toggle();
            openedMenu = null;
        }
    }
}
