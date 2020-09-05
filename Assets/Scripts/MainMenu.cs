using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject homeScreen;
    public GameObject optionsScreen;
    public GameObject highscoresScreen;
    public GameObject resolutionPicker;
    public GameObject volumeSlider;
    bool fullScreen;
    int width;
    int height;

    private void Start()
    {
        //This is required otherwise objects do not exist if you begin with them disabled / invisable.
        if(highscoresScreen)
        highscoresScreen.SetActive(false);
        optionsScreen.SetActive(false);

        width = 1920;
        height = 1080;
        fullScreen = false;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void HomeDisplay()
    {
        optionsScreen.SetActive(false);
        homeScreen.SetActive(true);
        if (highscoresScreen)
        {
            highscoresScreen.SetActive(false);
        }
    }

    public void HighScoresDisplay()
    {
        homeScreen.SetActive(false);
        highscoresScreen.SetActive(true);
    }

    public void OptionsDisplay()
    {
        homeScreen.SetActive(false);
        optionsScreen.SetActive(true);
    }

    public void changeResolution()
    {
        string temp = resolutionPicker.GetComponent<TMP_Dropdown>().options[resolutionPicker.GetComponent<TMP_Dropdown>().value].text;
        Debug.Log(temp);
        width = Int32.Parse(temp.Split(' ')[0]);
        height = Int32.Parse(temp.Split(' ')[2]);
        Screen.SetResolution(width, height, fullScreen);
    }

    public void toggleFullScreen()
    {
        fullScreen = !fullScreen;
        Screen.SetResolution(width, height, fullScreen);
    }

    public void changeVolume()
    {
        //Need to set up an Audio mixer with a master volume, then tie this to that
        //AudioSource.volume = volumeSlider.GetComponent<Slider>().value;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
