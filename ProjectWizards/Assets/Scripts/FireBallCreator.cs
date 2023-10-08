using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCreator : MonoBehaviour
{
    public float fireSpeed;

    private Rigidbody2D rb;

    public GameObject fireBallEffect;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(fireSpeed*transform.localScale.x, 0);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player1")
        {
            FindAnyObjectByType<GameManager>().HurtP1();
        }
        


        Instantiate(fireBallEffect,transform.position,transform.rotation); // creates an object in the world
        Destroy(gameObject);

    }
}
