﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene(1);
    }

    public void OpenCredits() {
        SceneManager.LoadScene(7);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void ReturnToMainMenu() {
        SceneManager.LoadScene(0);
    }
}
