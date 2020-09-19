using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class gun : MonoBehaviour
{
    public GameObject projectile;
    public float bulletDespawnTime = 2.0f;
    public GameObject player;

    public ParticleSystem drip;
    public ParticleSystem top;
    public ParticleSystem center;

    // Start is called before the first frame update
    void Start()
    {
        drip.gameObject.SetActive(false);
        top.gameObject.SetActive(false);
        center.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !player.GetComponent<FirstPersonController>().paused)
        {
            Transform fireLocation = gameObject.transform.GetChild(0);
            GameObject temp = Instantiate(projectile, fireLocation.position, fireLocation.rotation);
            temp.GetComponent<MeshRenderer>().enabled = false;
            temp.GetComponent<Rigidbody>().AddForce(transform.forward * 1000, ForceMode.Force);
            Destroy(temp, bulletDespawnTime);


            //Particles
            StartCoroutine(particleTimer(1.2f));
        }
    }

    IEnumerator particleTimer(float time)
    {
        drip.gameObject.SetActive(true);
        top.gameObject.SetActive(true);
        center.gameObject.SetActive(true);

        yield return new WaitForSeconds(time);
        drip.gameObject.SetActive(false);
        top.gameObject.SetActive(false);
        center.gameObject.SetActive(false);
    }
}

