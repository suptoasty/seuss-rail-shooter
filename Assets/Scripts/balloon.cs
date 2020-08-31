using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class balloon : MonoBehaviour
{
   public string word = "";
   public float speed = 10.0f;
   public bool randomSpeed = false;
   public bool randomDespawn = false;
   public float despawnTime = 10.0f;
   public gameManager manager;

   private void Start() {
      manager = gameManager.instance;
      if(randomSpeed) {
         speed = Random.Range(15.0f, 50.0f);
      }

      Rigidbody body = GetComponent<Rigidbody>();
      body.AddForce(transform.up * speed, ForceMode.Acceleration);
      
      Text text = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>();
      text.text = word;
      if(randomDespawn) {
         Destroy(gameObject, Random.Range(0, despawnTime));
      } else {
         Destroy(gameObject, despawnTime);
      }
   }

   private void OnTriggerEnter(Collider other) {
      if(other.gameObject.tag == "Projectile") {
         if(manager.isCorrect(word)) {
            //give points
            manager.incrementScore();
         } else {
            //lose health???
         }
         pop();
         Destroy(other.gameObject);
      }
   }

   public void pop() {
      //swap out models and deinstance this object
      Destroy(this.gameObject);
   }
}
