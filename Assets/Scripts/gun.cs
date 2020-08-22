using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Transform fireLocation = gameObject.transform.GetChild(0);
            GameObject temp = Instantiate(projectile, fireLocation.position, fireLocation.rotation);
            temp.GetComponent<Rigidbody>().AddForce(transform.forward * 1000, ForceMode.Force);
            StartCoroutine(destroyTimer(2, temp));
        }
    }
    
    IEnumerator destroyTimer(int time, GameObject bullet)
    {
        yield return new WaitForSeconds(time);
        Destroy(bullet);
    }
}
