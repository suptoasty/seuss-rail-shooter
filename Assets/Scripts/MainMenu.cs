using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject homeScreen;
    public GameObject optionsScreen;
    public GameObject highscoresScreen;
    public GameObject prizeScreen;
    public GameObject resolutionPicker;
    public GameObject volumeSlider;
    public GameObject sideMenu;

    public AudioMixer masterVolume;

    bool reset;
    bool fullScreen;
    int width;
    int height;

    public List<GameObject> prizeList;
    public List<GameObject> itemList;

    private void Start()
    {
        reset = false;
        

        //This is required otherwise objects do not exist if you begin with them disabled / invisable.
        if (highscoresScreen)
        {
            highscoresScreen.SetActive(false);
            prizeScreen.SetActive(false);
            sideMenu.SetActive(false);
            prizeManagement();

            Cursor.visible = (true);
            Cursor.lockState = CursorLockMode.None;
        }
       
        optionsScreen.SetActive(false);
        
        width = 1920;
        height = 1080;
        fullScreen = false;
    }

    public void PlayGame()
    {
        reset = true;
        SceneManager.LoadScene(1);

    }
    public void SideMenuDisplay()
    {
        sideMenu.SetActive(!sideMenu.activeSelf);
    }

    public void HomeDisplay()
    {
        optionsScreen.SetActive(false);
        homeScreen.SetActive(true);
        if (highscoresScreen)
        {
            highscoresScreen.SetActive(false);
            prizeScreen.SetActive(false);
        }
    }

    public void HighScoresDisplay()
    {
        homeScreen.SetActive(false);
        sideMenu.SetActive(false);
        highscoresScreen.SetActive(true);
    }

    public void OptionsDisplay()
    {
        if(sideMenu)
        sideMenu.SetActive(false);

        homeScreen.SetActive(false);
        optionsScreen.SetActive(true);
    }

    public void PrizeDisplay()
    {
        if(sideMenu)
        sideMenu.SetActive(false);

        homeScreen.SetActive(false);
        prizeScreen.SetActive(true);
    }

    public void changeResolution()
    {
        string temp = resolutionPicker.GetComponent<TMP_Dropdown>().options[resolutionPicker.GetComponent<TMP_Dropdown>().value].text;
        //Debug.Log(temp);
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
        masterVolume.SetFloat("MasterVolume", volumeSlider.GetComponent<Slider>().value);
    }

    public void prizeManagement()
    {
        //item n = sum(n*100, from 1 to n) points
        float prizeUnlock = getPrizePercentage();
        int unlockedPrizes = (int)Math.Floor(prizeUnlock);
        Debug.Log("PrizeUnlock Percent: " + prizeUnlock);
        Debug.Log("UnlockedPrizes: " + unlockedPrizes);

        if(unlockedPrizes <= 0){
            
            for(int i = 0; i < prizeList.Count; i++)
            {
                prizeList[i].GetComponent<Image>().enabled = true;
                prizeList[i].GetComponent<Slider>().value = 0.0f;
            }

            return;
        }

        //Set prizes active for all that are unlocked
        for(int i = 0; i < unlockedPrizes && i < prizeList.Count; i++)
        {
            prizeList[i].GetComponent<Image>().enabled = false;
            prizeList[i].GetComponent<Slider>().value = 1.0f;
            itemList[i].SetActive(true);
        }

        //If not all prizes are unlocked, set the percentage for the next item
        if(unlockedPrizes < 10)
        {
            float percent = (float)(prizeUnlock - Math.Floor(prizeUnlock));
            prizeList[unlockedPrizes].GetComponent<Slider>().value = percent;
        }
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(1);
    }

    private int getSum(int n)
    {
        if (n == 1)
        {
            return 100;
        }

        else
        {
            return (n * 100) + getSum(n - 1);
        }
    }

    private float getPrizePercentage()
    {
        if(PlayerPrefs.GetFloat("totalScore") < 100)
        {
            return PlayerPrefs.GetFloat("totalScore") / 100;
        }

        else if (PlayerPrefs.GetFloat("totalScore") < 300)
        {
            return 1 + (PlayerPrefs.GetFloat("totalScore") - 100) / 200;
        }

        else if (PlayerPrefs.GetFloat("totalScore") < 600)
        {
            return 2 + (PlayerPrefs.GetFloat("totalScore") - 300) / 300;
        }

        else if(PlayerPrefs.GetFloat("totalScore") < 1000)
        {
            return 3 + (PlayerPrefs.GetFloat("totalScore") - 600) / 400;
        }

        else if(PlayerPrefs.GetFloat("totalScore") < 1500)
        {
            return 4 + (PlayerPrefs.GetFloat("totalScore") - 1000) / 500;
        }

        else if(PlayerPrefs.GetFloat("totalScore") < 2100)
        {
            return 5 + (PlayerPrefs.GetFloat("totalScore") - 1500) / 600;
        }

        else if(PlayerPrefs.GetFloat("totalScore") < 2800)
        {
            return 6 + (PlayerPrefs.GetFloat("totalScore") - 2100) / 700;
        }

        else if(PlayerPrefs.GetFloat("totalScore") < 3600)
        {
            return 7 + (PlayerPrefs.GetFloat("totalScore") - 2800) / 800;
        }

        else if (PlayerPrefs.GetFloat("totalScore") < 4500)
        {
            return 8 + (PlayerPrefs.GetFloat("totalScore") - 3600) / 900;
        }

        else if (PlayerPrefs.GetFloat("totalScore") < 5500)
        {
            return 9 + (PlayerPrefs.GetFloat("totalScore") - 4500) / 1000;
        }

        else
        {
            return 10;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void endOfGame()
    {
        prizeManagement();
        PrizeDisplay();
    }

    public void quitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void resetScore(){
        PlayerPrefs.SetFloat("totalScore", 0.0f);
        prizeManagement();
    }
}
