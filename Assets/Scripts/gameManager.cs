using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public bool hardMode = false;
    private int score = 0;
    public int timer = 180; //Seconds
    public GameObject timerObj;
    private int lives = 0;
    public int maxLives = 4;
    public HealthControl healthUI;
    public List<string> rhyme;
    public string currentWord = "";
    public static gameManager instance = null;
    public List<string>[] wordDictionary = new List<string>[] {
        new List<string> { "apple", "grapple" },
        new List<string> { "cat", "bat", "sat" },
        new List<string> { "dog", "fog", "log", "frog" },
        new List<string> { "ball", "fall", "tall", "all", "call" },
        new List<string> { "right", "kite", "tonight" },
        new List<string> { "owl", "towel", "growl" },
        new List<string> { "bore", "four", "roar" },
        new List<string> { "rock", "chalk", "hawk" },
        new List<string> { "face", "place", "race" },
        new List<string> { "boat", "coat", "float" },
        new List<string> { "fan", "can", "pan", "van" },
        new List<string> { "dice", "mice", "rice" },
        new List<string> { "feet", "sweet" },
        new List<string> { "peg", "leg" },
        new List<string> { "jug", "mug" },
        new List<string> { "school", "pool" },
        new List<string> { "honey", "money" },
        new List<string> { "tree", "bee" }
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
        setTimer();
        resetScore();
        StartCoroutine(timerCoroutine());
    }

    void Update() {
        //GameObject[] balloons = GameObject.FindGameObjectsWithTag("balloon");
        //if(balloons.Length == 0 && WaypointManager.instance.isAtDest()) {
        //    WaypointManager.instance.GotoNextPoint();
        //    WaypointManager.instance.stop = false;
        //}
    }

    public void increaseLives()
    {
        lives++;
        healthUI.decrementHealth();
    }

    public void decreaseLives() {
        lives--;
        healthUI.decrementHealth();
    }

    public void resetLives() {
        lives = maxLives;
        healthUI.setHealth(lives);
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

    private void setTimer()
    {
        if(timer % 60 > 9)
            timerObj.GetComponent<TextMeshProUGUI>().text = (timer / 60).ToString() + ":" + (timer % 60).ToString();
        else
            timerObj.GetComponent<TextMeshProUGUI>().text = (timer / 60).ToString() + ":" + (timer % 60).ToString() + "0";
    }

    IEnumerator timerCoroutine()
    {
        yield return new WaitForSeconds(1);
        if(timer > 0)
        {
            timer--;
            setTimer();
            StartCoroutine(timerCoroutine());
        }
    }
}
