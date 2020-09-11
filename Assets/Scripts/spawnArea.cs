using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnArea : MonoBehaviour
{
    public objectSpawner spawner;
    public bool isActive = true;
    public int spawnNumber = 0;
    public bool randomSpawnNumber = false;

    void Start() {        
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player" && isActive) {
            spawner.spanwObjects(Random.Range(1, spawnNumber), randomSpawnNumber);
            isActive = false;
        }
    }
}
