using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Components
    Transform playerTransform;
    public Rigidbody2D playerRb;

    //Player horizontal mvment
    public float playerSpeed;
    public float normalSpeed;
    public float decreasedSpeed;
    public float playerHorizontal;
    public float maxSpeed;
  
    //jumping
    bool onGround;
    public float jumpForce = 200;
    

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
    }

     void FixedUpdate()
    {
        //Horizontal movement
        playerHorizontal = Input.GetAxis("Horizontal");
        playerRb.AddForce(new Vector2(playerHorizontal * playerSpeed * Time.fixedDeltaTime, 0));

        if (playerHorizontal == 0)
        {
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);
        }
        if (playerRb.velocity.x > maxSpeed)
        {
            playerRb.velocity = new Vector2(maxSpeed, playerRb.velocity.y);
        }
    }


    void Update()
    {
        //flips player according to the facing direction
        flipPlayer();

        //gets player input

        if (Input.GetButtonDown("Jump") && onGround)
        {
            playerRb.AddForce(new Vector2(0, jumpForce));
        }

        //decreases horizontal movement if not on ground/jumped
        if(onGround == false)
        {
            playerSpeed = decreasedSpeed;
        }
        if (onGround == true)
        {
            playerSpeed = normalSpeed;
        }
        
        
    }

    //checking for ground collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            onGround = false;
        }
    }

    //flipping player
    void flipPlayer()
    {
        if(playerHorizontal < 0)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRb.velocity.x), 1f);
        }
        if(playerHorizontal > 0)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRb.velocity.x), 1f);
        }
    }
    
}
