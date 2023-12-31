using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D rb;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode throwBall;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;

    private Animator anim;

    public GameObject snowBall;
    public Transform throwPoint;
    public AudioSource throwSound;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded= Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius,whatIsGround);
        
        if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        { 
            rb.velocity= new Vector2(0,rb.velocity.y);
        }

        if(Input.GetKeyDown(jump)&& isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if(Input.GetKeyDown(throwBall))
            {
          GameObject ballClone= (GameObject)Instantiate(snowBall, throwPoint.position, throwPoint.rotation);
            ballClone.transform.localScale=transform.localScale; //script player'a ili�tirildi�i i�in onu baz al�yor.
            anim.SetTrigger("Throw");
            throwSound.Play();
        }

        if(rb.velocity.x<0)
        {
            transform.localScale= new Vector3(-1,1,1); //********
        }
        else if(rb.velocity.x>0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("Speed",Mathf.Abs(rb.velocity.x));
        anim.SetBool("Grounded", isGrounded);

    }
}
