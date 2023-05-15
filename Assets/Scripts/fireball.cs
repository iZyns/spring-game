using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
        public float fireballSpeed;
        //public GameObject explode;

        private Rigidbody2D rigidbody;
        [SerializeField] private AudioSource hitFire;
        
    // Start is called before the first frame update
    void Start()
    {
         rigidbody = GetComponent<Rigidbody2D>();
         rigidbody.velocity  = transform.right*fireballSpeed;
         hitFire.Play();
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Enemy"){
                 //Destroy(collision.gameObject);
                Destroy(gameObject);
        }
    }


}