using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public float axeSpeed;

    private Rigidbody2D rigidbody;
    [SerializeField] private AudioSource axeThrowEffect;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.right * axeSpeed;
        axeThrowEffect.Play();
    }

    void Update()
    {
        transform.Rotate(transform.forward, -300.0f * Time.smoothDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {

            Destroy(gameObject);
        }
    }

}