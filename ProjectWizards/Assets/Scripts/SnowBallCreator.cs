using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallCreator : MonoBehaviour
{
    public float ballSpeed;

    private Rigidbody2D rb;

    public GameObject snowBallEffect;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(ballSpeed*transform.localScale.x, 0);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player1")
        {
            FindAnyObjectByType<GameManager>().HurtP1();
        }
        if (other.tag == "Player2")
        {
            FindAnyObjectByType<GameManager>().HurtP2();
        }


        Instantiate(snowBallEffect,transform.position,transform.rotation); // creates an object in the world
        Destroy(gameObject);

    }
}
