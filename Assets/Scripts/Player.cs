using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public Transform firePosition;
    public GameObject projectile;
    //public GameObject arrow;
    //public GameObject throwAxe;

    


    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {  
         // to fire fireball
        if(Input.GetKeyDown(KeyCode.Space)){

            Instantiate(projectile, transform.position, transform.rotation);
        }

        // // to fire arrow
        // if(Input.GetKeyDown(KeyCode.W)){

        //     Instantiate(arrow, transform.position, transform.rotation);
        // }

        // if(Input.GetKeyDown(KeyCode.E)){

        //     Instantiate(throwAxe, transform.position, transform.rotation);
        // }

        
    }
}
