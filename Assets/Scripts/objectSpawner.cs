using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawner : MonoBehaviour
{
    public gameManager manager;
    public balloon spawnableObject;
    private List<string> rhymes;
    public float spawnTolerance = 2.0f;

    public void Start() {
        spanwObjects(10);
    }

    public void spanwObjects(int amount = 1, bool random = true) {
        if(random) {
            amount = Mathf.RoundToInt(Random.Range(3.0f, 10.0f));
        }

        //spawn random rhyming words
        //### Code here

        //spawn other random word
        for(int i = 0; i < amount; i++) {
            //instaniate new ballon
            balloon newBallon = Instantiate(spawnableObject, getRandomPosition(), Quaternion.identity);
            Debug.Log(newBallon.transform.position);
           
            //get word from dictionary that is not right word
            string word = manager.getWord();
            newBallon.word = word;
        }
    }

    //returns random position balloon will spawn at
    public Vector3 getRandomPosition() {
        Debug.Log(Camera.main.nearClipPlane);
        Debug.Log(Camera.main.farClipPlane);
        return Camera.main.ScreenToWorldPoint(
            new Vector3(
                Random.Range(0, Screen.width),
                Random.Range(0, Screen.height),
                Random.Range(Camera.main.nearClipPlane * spawnTolerance, Camera.main.farClipPlane / (Camera.main.nearClipPlane * Camera.main.farClipPlane) * spawnTolerance)
            )
        );
    }
}
