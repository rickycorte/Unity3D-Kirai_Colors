/*
  Unity3D Kirai Colors

  Copyright (c) 2015-2016 RickyCoDev
  Licensed under Mit Licence
*/
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

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

        [Header("Score references")]
        public Text HeaderText; // text displayed on top
        public Text ScoreText;
        public Text ScoreAdded;

        [Header("Buttons references")]
        public List<GameButton> GameButtons; // list of 9 buttons references

        [Header("TimeBar references")]
        public CustomSlider bar;

        [Header("Menus references")]
        public GameOverMenu gmOverMenu;

        public GameObject GameView;

        [Header("Music references")]
        public AudioClip TimeAttack_Music;
        public AudioClip Rush_Music;

    }
}
