using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPortal : MonoBehaviour
{
    public GameObject newLocation;

    // // private void Start() {
    // // }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            Debug.Log("Player Entered Portal");
            other.gameObject.transform.position = newLocation.gameObject.transform.position;

        }
    }


}
