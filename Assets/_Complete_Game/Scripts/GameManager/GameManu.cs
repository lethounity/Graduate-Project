﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManu : MonoBehaviour {

    public void LoadScene(int level)
    {
        Application.LoadLevel(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
