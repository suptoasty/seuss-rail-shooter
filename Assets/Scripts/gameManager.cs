using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    private int score = 0;
    private int lives = 0;
    public int maxLives = 3;

    // Start is called before the first frame update
    void Start()
    {
        resetScore();
    }

    public void decreaseLives() {
        lives--;
    }

    public void resetLives() {
        lives = maxLives;
    }

    public void addScore(int amount) {
        score += amount;
    }

    public void incrementScore() {
        score++;
    }

    public void resetScore() {
        score = 0;
    }
}
