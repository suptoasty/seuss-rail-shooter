using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawner : MonoBehaviour
{
    public gameManager manager;
    public GameObject spawnableObject;
    public float spawnTolerance = 2.0f;
    // public static objectSpawner instance = null;
    public BoxCollider spawnField = null;

    // void Awake() {
    //     if(instance == null) {
    //         instance = this;
    //     } else if(instance != this) {
    //         Destroy(gameObject);
    //     }
    // }

    public void Start()
    {
        manager = gameManager.instance;
    }

    public void spanwObjects(int amount = 1, bool random = true)
    {
        if (random)
        {
            amount = Mathf.RoundToInt(Random.Range(3.0f, 7.0f));
        }
        manager.rhyme = manager.getRhyme();
        manager.currentWord = manager.rhyme[Random.Range(0, manager.rhyme.Count)];
        manager.rhymeDisplay.text = "Rhyme with: " + manager.currentWord;

        balloon rhymingBalloon = Instantiate(spawnableObject, getPointInCollision(spawnField), Quaternion.identity).GetComponent<balloon>();
        string rhymingWord = manager.rhyme[Random.Range(0, manager.rhyme.Count)];
        while (rhymingWord == manager.currentWord)
        {
            rhymingWord = manager.rhyme[Random.Range(0, manager.rhyme.Count)];
        }
        rhymingBalloon.word = rhymingWord;
        //rhymingBalloon.randomDespawn = false;

        // Debug.Log("CurrentWord: "+manager.currentWord);
        // Debug.Log("RhymingWord: "+rhymingWord);

        //for all others spawn with random word
        amount++; //account for right ballon
        for (int i = 0; i < amount; i++)
        {
            //instaniate new ballon
            balloon newBallon = Instantiate(spawnableObject, getPointInCollision(spawnField), Quaternion.identity).GetComponent<balloon>();
            newBallon.transform.position = getPointInCollision(spawnField);
            // Debug.Log(newBallon);

            //get word from dictionary that is not right word
            string word = manager.getWord();
            while (word == manager.currentWord)
            {
                word = manager.getWord();
            }
            newBallon.word = word;
        }
    }

    //returns random position balloon will spawn at
    public Vector3 getRandomPosition()
    {
        // Debug.Log(Camera.main.nearClipPlane);
        // Debug.Log(Camera.main.farClipPlane);
        return Camera.main.ScreenToWorldPoint(
            new Vector3(
                Random.Range(0, Screen.width),
                Random.Range(0, Screen.height),
                Random.Range(Camera.main.nearClipPlane * spawnTolerance, Camera.main.farClipPlane / (Camera.main.nearClipPlane * Camera.main.farClipPlane) * spawnTolerance)
            )
        );
    }

    //takes boxCollder and produces a random point in that box
    public Vector3 getPointInCollision(BoxCollider box)
    {
        Vector3 temp = new Vector3(
        Random.Range(box.bounds.min.x, box.bounds.max.x),
        Random.Range(box.bounds.min.y, box.bounds.max.y),
        Random.Range(box.bounds.min.z, box.bounds.max.z));

        return temp;
    }
}
