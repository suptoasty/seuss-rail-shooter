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
    public List<string> rhyme;
    public string currentWord = "";

    public static gameManager instance = null;
    public List<string>[] wordDictionary = new List<string>[] {
        new List<string> { "apple", "grapple" },
        new List<string> { "cat", "bat" },
        new List<string> { "dog", "fog" }
    };
    public List<string>[] advancedWordDictionary = new List<string>[] {
        new List<string> { "prestidigitation" },
    };
    void Awake() {
        if(instance == null) {
            instance = this;
        } else if(instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start() {

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

    public bool isCorrect(string guess) {
        if(rhyme.Contains(guess)) {
            return true;
        }

        return false;
    }

    public string getWord() {
        if(!hardMode) {
            var list = wordDictionary[Random.Range(0, wordDictionary.Length)];
            return list[Random.Range(0, list.Count)];
        } else {
            var list = advancedWordDictionary[Random.Range(0, advancedWordDictionary.Length)];
            return list[Random.Range(0, list.Count)];
        }
    }

    public List<string> getRhyme() {
        if(!hardMode) {
            return wordDictionary[Random.Range(0, wordDictionary.Length)];
        } else {
            return advancedWordDictionary[Random.Range(0, advancedWordDictionary.Length)];
        }
    }
}
