/*
  Unity3D Kirai Colors

  Copyright (c) 2015-2016 RickyCoDev
  Licensed under Mit Licence
*/
using UnityEngine;
using System.Collections;

namespace Game
{
    public class EventMaster : MonoBehaviour
    {

        public delegate void BaseEventHandler();

        public BaseEventHandler OnWrongButtonClick;
        public BaseEventHandler OnRightButtonClick;

        public BaseEventHandler OnTimeOut;


        public void WrongButtonClick()
        {
            if (OnWrongButtonClick != null)
            {
                OnWrongButtonClick();
            }
            else Debug.LogWarning("OnWrongButtonClick event called but nothing to do");
        }

        public void RightButtonClick()
        {
            if (OnRightButtonClick != null)
            {
                OnRightButtonClick();
            }
            else Debug.LogWarning("OnRightButtonClick event called but nothing to do");
        }
    }
}
