using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloon : MonoBehaviour
{
   public string word = "";
   public float speed = 10.0f;
   public bool randomSpeed = false;

   private void Start() {
      if(randomSpeed) {
         speed = Random.Range(15.0f, 50.0f);
      }

      Rigidbody body = GetComponent<Rigidbody>();
      body.AddForce(transform.up * speed, ForceMode.Acceleration);
      
   }
}
