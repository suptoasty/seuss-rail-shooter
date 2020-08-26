﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawner : MonoBehaviour
{
    public gameManager manager;
    public ballon spawnableObject;
    public string rightWord = "";

    public void spanwObjects(int amount = 1, bool random = true) {
        if(random) {
            amount = Mathf.RoundToInt(Random.Range(3.0f, 10.0f));
        }

        //set balloon with right answer here and spawn
        //### Code here

        //for all others spawn with random word
        amount++; //account for right ballon
        for(int i = 0; i < amount; i++) {
            //instaniate new ballon
            ballon newBallon = Instantiate(spawnableObject, getRandomPosition(), Quaternion.identity);
           
            //get word from dictionary that is not right word
            string word = manager.getWord();
            while(word == rightWord) {
                word = manager.getWord();
            }
            newBallon.word = word;
        }
    }

    //returns random position balloon will spawn at
    public Vector3 getRandomPosition() {
        return new Vector3();
    }
}
