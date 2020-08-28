using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public bool hardMode = false;
    private int score = 0;
    private int lives = 0;
    public int maxLives = 3;
    public string[] wordDictionary = new string[] {
        "apple", "dog", "cat", "bat"
    };
    public string[] advancedWordDictionary = new string[] {
        "prestidigitation"
    };
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

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

    public string getWord() {
        if(!hardMode) {
            return wordDictionary[Random.Range(0, wordDictionary.Length)];
        } else {
            return advancedWordDictionary[Random.Range(0, advancedWordDictionary.Length)];
        }
    }
}
