using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    private bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
     private void Update()
    {
        //check if esc key is pressed 
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            //if game is already paused, resume it.
            if(isPaused)
            {
                ResumeGame();
            }

            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pausePanel.SetActive(true); //Show the pause menu screen
        Time.timeScale = 0f; //Freeze the game.
    }

    public void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false); //Hide the pause menu screen.
        Time.timeScale = 1f; //Unfreeze the game.
    }
}
