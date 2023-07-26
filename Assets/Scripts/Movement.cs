using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Player contrl
    public float playerSpeed;
    public float normalSpeed;
    public float decreasedSpeed;
    public float playerHorizontal;
    public float maxSpeed;
    Transform playerTransform;
    Vector2 movementDir;
    Rigidbody2D playerRb;
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            onGround = true;
            Debug.Log("pass");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            onGround = false;
        }
    }

    void flipPlayer()
    {
        if(playerHorizontal < 0) 
        {
            transform.localScale = new Vector2(Mathf.Sign(playerHorizontal), 1f);
        }
        if (playerHorizontal > 0)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerHorizontal), 1f);
        }
    }
    
}
