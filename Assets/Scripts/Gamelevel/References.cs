using UnityEngine;
using System.Collections;

namespace Game
{
    //references to important gameobjects.
    public class References : MonoBehaviour
    {

        public static EventMaster evMaster;
        public EventMaster ev;

        // Use this for initialization
        void OnEnable()
        {
            evMaster = ev;
        }


    }
}
