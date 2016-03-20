/*
  Unity3D Kirai Colors

  Copyright (c) 2015-2016 RickyCoDev
  Licensed under Mit Licence
*/
using UnityEngine;
using System.Collections;

namespace Game
{
    public class GameMode_SetUP : MonoBehaviour
    {
        public bool isTestMode = false;

        [SerializeField] GameMode.Type gameMode;


        // Use this for initialization
        void Start()
        {
            if (!isTestMode)
            {
                gameMode = (GameMode.Type)GetGamemodeFromDrive();
            }
            else
            {
                Debug.LogWarning("Game running in test mode! -> no gamemode read from disk!");
            }

            GameMode gm = null;

            if (gameMode == GameMode.Type.Rush || gameMode == GameMode.Type.Rush_Crazy || gameMode == GameMode.Type.Rush_Insane)
            {
                 gm = gameObject.AddComponent<Rush>();
            }

            if (gameMode == GameMode.Type.TimeAttack || gameMode == GameMode.Type.TimeAttack_Long || gameMode == GameMode.Type.TimeAttack_Short)
            {
                gm = gameObject.AddComponent<TimeAttack>();
                //Debug.LogWarning("No Inplementation for TimeAttack!");
            }

            if(gm != null)
               gm.SetGameMode(gameMode);


        }

        int GetGamemodeFromDrive()
        {
            if (PlayerPrefs.HasKey("GameMode"))
                return PlayerPrefs.GetInt("GameMode");
            Debug.LogError("No Gamemode set!");
            return 0; // default gamemode
        }

    }
}
