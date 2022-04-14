using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audiomix;

    private bool isFullscreen = true;

    public void SetResolution(int index)
    {
        if (index == 0)
        {
            Screen.SetResolution(1920, 1080, isFullscreen);
        }
        else if (index == 1)
        {
            Screen.SetResolution(1280, 720, isFullscreen);

        }
        else if (index == 2)
        {
            Screen.SetResolution(800, 600, isFullscreen);

        }
    }

    public void SetQuality(int qualityIndex)
    {
         QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool fullscreen_enable)
    {
        Screen.fullScreen = fullscreen_enable;
        isFullscreen = fullscreen_enable;
    }

    public void SetMouseSensitivity(float value)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", value);
        
        //Sliderın stok değere eşitlenmesi
        if (GameObject.FindGameObjectWithTag("Player") != null) //Player Tagini aradığımda boş değil ise
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().mouseSensitivity = value;
        }
        
    }
    
    public void SetMasterVolume(float value)
    {
        audiomix.SetFloat("MasterVolume", value);
    }
    
    public void SetMusicVolume(float value)
    {
        audiomix.SetFloat("MusicVolume", value);
    }
}
