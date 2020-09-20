using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordSound : MonoBehaviour
{

    SoundManager soundman;
    Transform lastHit;
    // Start is called before the first frame update
    void Start()
    {
        soundman = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        lastHit = new GameObject().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(lastHit == null)
        {
            lastHit = new GameObject().transform;
        }

        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, (1 << LayerMask.NameToLayer("spawnObjects"))))
        {
            if(hit.transform != lastHit.transform)
            {
                lastHit = hit.transform;
                Debug.Log(hit.transform.name);
                string word = hit.transform.GetComponent<balloon>().word;
                soundman.playWord(word);
            }

        }
    }
}
