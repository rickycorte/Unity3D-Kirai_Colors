/*
  Unity3D Kirai Colors

  Copyright (c) 2015-2016 RickyCoDev
  Licensed under Mit Licence
*/
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackButtonHandler : MonoBehaviour {

    ButtonUtilities btnUt;

    void Start()
    {
        btnUt = GetComponent<ButtonUtilities>();
    }

    void HandleBack()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            btnUt.PopUpQuit();
        }
        else
        {
            btnUt.PopUpLoadMainMenu();
        }
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandleBack();
        }
	}
}
