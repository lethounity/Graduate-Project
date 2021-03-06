﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

   
    public Transform canvas;

	// Use this for initialization
	void Awake () {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
	}

    void setPlay()
    {
     
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    void gotoMainMenu(int level)
    {
        Application.LoadLevel(level);
    }

}
