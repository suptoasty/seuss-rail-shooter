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
    public float timer = 180; //Seconds
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

    public TextMeshProUGUI rhymeDisplay;
    private bool endGameTriggered = false;
    public SoundManager soundMan;
    public GameObject correct;
    public GameObject incorrect;

    void Awake() {
        if(instance == null) {
            instance = this;
        } else if(instance != this) {
            Destroy(gameObject);
        }
       // DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start() {
        setTimer();
        resetScore();
        resetLives();
        soundMan.introduction();
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            setTimer();
        }

        else if (!endGameTriggered)
        {
            endGameTriggered = true;
            endGame();
        }
    }

    public void resetLevel()
    {
       
        timerObj = GameObject.FindGameObjectWithTag("timer");
        healthUI = GameObject.FindGameObjectWithTag("playerUI").GetComponent<HealthControl>();
        rhymeDisplay = GameObject.FindGameObjectWithTag("rhyme").GetComponent<TextMeshProUGUI>();

        setTimer();
        resetScore();
        resetLives();
    }

    public void increaseLives()
    {
        if(lives < maxLives)
        {
            lives++;
            healthUI.incrementHealth();
        }
    }

    public void decreaseLives() {
        //Debug.Log(lives);
        if(lives > 1)
        {
            lives--;
            healthUI.decrementHealth();
        }

        else
        {
            lives--;
            healthUI.decrementHealth();
            endGame();
        }
    }

    public void resetLives() {
        lives = maxLives;
        healthUI.setHealth(lives);
    }

    public void addScore(int amount) {
        score += amount;
    }

    public void removeScore(int amount)
    {
        score -= amount;
        //Debug.Log(score);
    }


    public void incrementScore() {
        score++;
    }

    public void resetScore() {
        score = 0;
    }

    public bool isCorrect(string guess) {
        if(rhyme.Contains(guess)) {
            StartCoroutine(answerAnimation(1.2f, correct));
            soundMan.correctAnswer();
            return true;
        }

        StartCoroutine(answerAnimation(1.51f, incorrect));
        soundMan.incorrectAnswer();
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
            timerObj.GetComponent<TextMeshProUGUI>().text = ((int)timer / 60).ToString() + ":" + ((int)timer % 60).ToString();
        else
            timerObj.GetComponent<TextMeshProUGUI>().text = ((int)timer / 60).ToString() + ":0" + ((int)timer % 60).ToString();
    }

    private void endGame()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        //End Game
        if(lives < 1)
        {
            soundMan.conclusion(false);
        }

        else
        {
            soundMan.conclusion(true);
        }
        float temp = PlayerPrefs.GetFloat("totalScore");
        PlayerPrefs.SetFloat("totalScore", temp + score);
        Debug.Log(temp = PlayerPrefs.GetFloat("totalScore"));
        GameObject.FindGameObjectWithTag("playerUI").GetComponent<MainMenu>().endOfGame();
        StartCoroutine(endGameTimer(10.0f));
    }

    IEnumerator endGameTimer(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(0);
    }

    IEnumerator answerAnimation(float time, GameObject lucky)
    {
        Debug.Log(lucky);
        lucky.SetActive(true);
        yield return new WaitForSeconds(time);
        lucky.SetActive(false);
    }
}
