using UnityEngine;
using System.Collections;

namespace Game
{
    public class References : MonoBehaviour
    {

        public static EventMaster evMaster;
        public EventMaster ev;

        // Use this for initialization
        void Start()
        {
            evMaster = ev;
        }


    }
}
