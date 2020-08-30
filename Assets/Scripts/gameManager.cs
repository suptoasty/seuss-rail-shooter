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

    public List<string>[] wordDictionary = new List<string>[] {
        new List<string>() {"cat", "hat", "bat"},
        new List<string>() {"dog", "fog"},
        new List<string>() {"apple", "grapple"}
    };
    public List<string>[] advancedWordDictionary = new List<string>[] {
        new List<string>() {"prestidigitation", },
    };
    void Awake()
    {
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

    //get random word form dictionary
    public string getWord() {
        if(!hardMode) {
            var list = wordDictionary[Random.Range(0, wordDictionary.Length)] as List<string>;
            return list[Random.Range(0, list.Count)];
        } else {
            var list = advancedWordDictionary[Random.Range(0, advancedWordDictionary.Length)] as List<string>;
            return list[Random.Range(0, list.Count)];
        }
    }

    //return a slice of rhyms from dictionary
    public List<string> getRhyme() {
        if(!hardMode) {
            return wordDictionary[Random.Range(0, wordDictionary.Length)] as List<string>;
        } else {
            return advancedWordDictionary[Random.Range(0, advancedWordDictionary.Length)] as List<string>;
        }
    }
}
