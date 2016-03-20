/*
  Unity3D Kirai Colors

  Copyright (c) 2015-2016 RickyCoDev
  Licensed under Mit Licence
*/
using UnityEngine;
using System.Collections;

namespace Game
{
    public class Rush : GameMode
    {
        float MaxTimer = 5f;

        // Use this for initialization
        protected override void StartGame()
        {
            Debug.Log("Rush start");
            base.StartGame();
        }

        public override void SetGameMode(Type gm)
        {
            Gamemode = gm;
            base.SetGameMode(gm);
        }

        protected override void Init()
        {
            base.Init();
            switch (Gamemode)
            {
                case Type.Rush:
                    MaxTimer = 10;
                    PointsToAdd = 5;
                    break;
                case Type.Rush_Crazy:
                    MaxTimer = 6;
                    PointsToAdd = 10;
                    break;
                case Type.Rush_Insane:
                    MaxTimer = 3;
                    PointsToAdd = 20;
                    break;
                default:
                    Debug.LogError("Gamemode: "+ Gamemode.ToString()+" is NOT handled in rush script!");
                    break;
            }

            SetUp();

        }

        //prepere for this gamemode
        void SetUp()
        {
            timer = MaxTimer;
            _ref.bar.InvereAndSet(MaxTimer);
            ev.OnRightButtonClick += RightClick;
            ev.OnWrongButtonClick += WrongClick;
            music.clip = _ref.Rush_Music;
            music.Play();
        }

        protected override void OnDisable()
        {
            RemoveGM();
            base.OnDisable();
        }

        //remove settings for this gamemode
        void RemoveGM()
        {
            ev.OnRightButtonClick -= RightClick;
            ev.OnWrongButtonClick -= WrongClick;
        }

        //action for UpdateS
        void UpdateAction()
        {
            timer -= Time.deltaTime;
            UpdateBarTimer();
            UpdateBar();
            if (timer <= 0)
            {
                EndGame("TimeOut");
            }
        }

        void Update()
        {
            if (isStarted)
            {
                UpdateAction();
            }
        }

        void WrongClick()
        {
            EndGame("Wrong Color");
        }

        //correct click action for rush gm
        void RightClick()
        {
            AddScore();
            timer = MaxTimer;
            UpdateScoreText();
        }

        //update the Score: text
        void UpdateScoreText()
        {
            UpdateScoreText("Score: " + score);
        }

        void UpdateBar()
        {
           _ref.bar.SetSliderPos(timer);
        }

        //add score and update +pts message
        void AddScore()
        {
            int scoreToAdd = Mathf.RoundToInt(CalculateScoreToAdd(timer, PointsToAdd, MaxTimer));
            //Debug.Log("Score to add: " + CalculateScoreToAdd(timer, PointsToAdd, Rush_MaxTimer));
            _ref.ScoreAdded.text = "+" + scoreToAdd;
            score += scoreToAdd;
            //Rush_UpdateScoreText();
        }

        //caculate score based on a math function. Return vals: ptMAx-1
        float CalculateScoreToAdd(float tm, float ptMax, float tmMax) // riferimento alle foto allegates
        {
            tm = tmMax - tm; // correzione tempo decrescente
            //points = a*(tm^2)+b*(tm)+c
            float res = (ptMax - 1) / (tmMax * tmMax) * (tm * tm); // +a*(tm^2)
            res -= 2 * ((ptMax - 1) / tmMax) * tm; // +b*(tm)
            res += ptMax; // +c
            return res;
        }

        void EndGame(string motivation)
        {
            PlayerLevelManager.AddExp(score); // add score to player experince
            _ref.gmOverMenu.gameObject.SetActive(true);
            _ref.gmOverMenu.Rush_InfoPreset(score, motivation);
            StopGame();
        }


    }
}
