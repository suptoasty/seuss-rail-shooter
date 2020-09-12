using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class TogglePause : MonoBehaviour
{
    // Start is called before the first frame update.

    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public bool paused = false;
    public GameObject player;

    void Start()
    {
        paused = false;
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);

        Cursor.visible = (false);
        Cursor.lockState = CursorLockMode.Locked;

        GameObject.FindGameObjectWithTag("GameManager").GetComponent<gameManager>().resetLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            paused = !paused;

            if (paused)
            {
                pause();
            }

            else
            {
                unpause();
            }
        }


    }

    void pause()
    {
        player.GetComponent<FirstPersonController>().paused = true;
        pauseMenu.SetActive(true);
        Cursor.visible = (true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.0f;
    }

    void unpause()
    {
        player.GetComponent<FirstPersonController>().paused = false;
        pauseMenu.SetActive(false);
        Cursor.visible = (false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
    }
}
