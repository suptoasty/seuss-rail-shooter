using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour
{
    [SerializeField]
    private GameObject HeartFull;
    [SerializeField]
    private GameObject Heart3;
    [SerializeField]
    private GameObject Heart2;
    [SerializeField]
    private GameObject Heart1;
    private int health = 4;

    public void setHealth(int h)
    {
        health = h;
        updateUI();
    }

    public void decrementHealth()
    {
        if (health > 0)
        {
            health--;
            updateUI();
        }
    }

    public void incrementHealth()
    {
        if (health < 4)
        {
            health++;
        }
        updateUI();
    }

    void updateUI()
    {
        switch (health)
        {
            case 4:
                HeartFull.SetActive(true);
                break;

            case 3:
                HeartFull.SetActive(false);
                Heart3.SetActive(true);
                break;

            case 2:
                Heart3.SetActive(false);
                Heart2.SetActive(true);
                break;

            case 1:
                Heart2.SetActive(false);
                Heart1.SetActive(true);
                break;

            case 0:
                Heart1.SetActive(false);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                HeartFull.SetActive(false);
                break;
        }
           

    }

}
