using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class balloon : MonoBehaviour
{
   public string word = "";
   public float speed = 10.0f;
   public bool randomSpeed = false;
   public float despawnTime = 10.0f;

   private void Start() {
      if(randomSpeed) {
         speed = Random.Range(15.0f, 50.0f);
      }

      Rigidbody body = GetComponent<Rigidbody>();
      body.AddForce(transform.up * speed, ForceMode.Acceleration);
      
      Destroy(gameObject, despawnTime);
   }
   void Update() {
      Text text = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>();
      Debug.Log(text);
      text.text = word;
      // text.transform.LookAt(Camera.main.transform);
   }

   private void OnTriggerEnter(Collider other) {
      if(other.gameObject.tag == "Projectile") {
         bool isCorrect = false;
         //check if word is right

         if(isCorrect) {
            //give points
         } else {
            //lose health???
         }
      }
   }

   public void pop() {
      //swap out models and deinstance this object
   }
}
