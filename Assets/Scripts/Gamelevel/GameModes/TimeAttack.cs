/*
  Unity3D Kirai Colors

  Copyright (c) 2015-2016 RickyCoDev
  Licensed under Mit Licence
*/
using UnityEngine;
using System.Collections;

namespace Game
{
    public class TimeAttack : GameMode
    {

        int MaxScore = 25;

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
                case Type.TimeAttack_Short:
                    MaxScore = 25;
                    break;
                case Type.TimeAttack:
                    MaxScore = 50;
                    break;
                case Type.TimeAttack_Long:
                    MaxScore = 100;
                    break;
                default:
                    Debug.LogError("Gamemode: " + Gamemode.ToString() + " is NOT handled in timeattack script!");
                    break;
            }

            SetUp();

        }

        protected override void StartGame()
        {
            Debug.Log("Starting time attack");
            base.StartGame();
        }

        void SetUp()
        {
            PointsToAdd = 1;
            ev.OnRightButtonClick += addScore; // adds score before updating bar
            ev.OnRightButtonClick += UpdateBarPos; // update the bar fill
            ev.OnWrongButtonClick += WrongClick; // sets the action for wrong click
            _ref.bar.SetSliderMaxValue(MaxScore);
            UpdateScoreText("Progress: " + score + "/" + MaxScore);
            music.clip = _ref.TimeAttack_Music;
            music.Play();
        }


        protected override void OnDisable()
        {
            RemoveGM();
            base.OnDisable();
        }

        void RemoveGM()
        {
            ev.OnRightButtonClick -= UpdateBarPos;
            ev.OnWrongButtonClick -= WrongClick;
            ev.OnRightButtonClick -= addScore;
        }


        public void addScore()
        {
            //TODO:calcolare punteggio in base a tempo
            _ref.ScoreAdded.text = "+" + PointsToAdd;
            score += PointsToAdd;

        }

        //function to call in update delegate
        void TimerAction()
        {
            timer += Time.deltaTime;
            UpdateBarTimer();
        }

        //function to call when click on wrong button
        void WrongClick()
        {
            timer += 10f;
        }

        //update barr fill and also scoretext
        void UpdateBarPos()
        {
            _ref.bar.SetSliderPos(score);
            UpdateScoreText("Progress: " + score + "/" + MaxScore);
            CheckForEndGame();
        }

        //Check for the end of time attack
        void CheckForEndGame()
        {
            if (score >= MaxScore)
            {
                EndGame();
            }

        }

        //end the game
        void EndGame()
        {
            PlayerLevelManager.AddExp(score); // add score to player experince
            _ref.gmOverMenu.gameObject.SetActive(true);
            //gmOverMenu.SetInfo(GameMode, timer);
            _ref.gmOverMenu.TimeAttack_InfoPeset(timer);
            StopGame();
        }

        void Update()
        {
            if (isStarted)
            {
                TimerAction();
            }
        }
    }
}
