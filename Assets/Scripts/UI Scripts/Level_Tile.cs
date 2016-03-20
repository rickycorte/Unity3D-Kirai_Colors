/*
  Unity3D Kirai Colors

  Copyright (c) 2015-2016 RickyCoDev
  Licensed under Mit Licence
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UI_Scripts
{
    public class Level_Tile : MonoBehaviour
    {
        [SerializeField]Text levelText;

        // Use this for initialization
        void Start()
        {
            levelText.text = PlayerLevelManager.currentLevel.ToString();
        }

    }
}
