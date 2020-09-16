using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class balloon : MonoBehaviour
{
   public string word = "";
   public float speed = 10.0f;
   public bool randomSpeed = false;
    private bool active = true;
   [SerializeField]
   private bool randomDespawn = false;
   public float despawnTime = 10.0f;
   public gameManager manager;

   private void Start() {
        active = true;
        randomDespawn = false;
        randomSpeed = false;
        despawnTime = 10.0f;

      manager = gameManager.instance;
      if(randomSpeed) {
         speed = Random.Range(15.0f, 50.0f);
      }

      Rigidbody body = GetComponent<Rigidbody>();
        body.constraints = RigidbodyConstraints.FreezeAll;

      body.AddForce(transform.up * speed, ForceMode.Acceleration);
      
      Text text = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>();
      text.text = word;
   
        text.color = new Color(255, 237, 172); 
      if(randomDespawn) {
         Destroy(gameObject, Random.Range(0, despawnTime));
      } else {
         Destroy(gameObject, despawnTime);
      }
   }

   void Update() {
      // transform.LookAt(Camera.main.transform, Vector3.up);
      transform.GetChild(0).transform.LookAt(Camera.main.transform);
   }

   private void OnTriggerEnter(Collider other) {
      if(other.gameObject.tag == "Projectile" && active) {
            active = false;
         if(manager.isCorrect(word)) {
            //give points
            manager.addScore(30);
            manager.increaseLives();
         } else {
            //lose health
            manager.removeScore(5);
            manager.decreaseLives();
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
