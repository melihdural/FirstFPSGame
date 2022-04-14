using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isGamePause = false;
    public GameObject pauseMenu_obj;

    public bool isGameOver = false;

    public GameObject player, pistol;

    public AudioSource music;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            if (!isGamePause)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }


    private void PauseGame()
    {
        //Set Time Scale
        Time.timeScale = 0;
        
        //Disable Player Movement and Pistol
        player/*GameObject.FindGameObjectWithTag("Player")*/.GetComponent<PlayerMovement>().enabled = false;
        pistol.GetComponent<WeaponControl>().enabled = false;
        
        //Set Cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        //Pause Music
        music.Pause();

        //Pause Menu
        pauseMenu_obj.SetActive(true);
     
        //Set Boolean
        isGamePause = true;
    }

    private void ResumeGame()
    {
        //Set Time Scale
        Time.timeScale = 1;
        
        //Enable Player Movement and Pistol
        player/*GameObject.FindGameObjectWithTag("Player")*/.GetComponent<PlayerMovement>().enabled = true;
        pistol.GetComponent<WeaponControl>().enabled = true;
        
        //Set Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //Pause Music
        music.UnPause();
        
        //Pause Menu
        pauseMenu_obj.SetActive(false);
        
        //Set Boolean
        isGamePause = false;
       
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SettingsMenu()
    {
        
    }
}
