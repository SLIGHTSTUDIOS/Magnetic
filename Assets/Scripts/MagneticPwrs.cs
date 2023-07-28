using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticPwrs : MonoBehaviour
{
    bool nEnemyDetect;
    bool pEnemyDetect;
    Rigidbody2D enemyRb;
    public Vector2 magnetForce;
    Movement movement;
    Transform playerTransform;

    private void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checking for enemy collision
        if (collision.gameObject.tag == "negativeEnemy")
        {
            Debug.Log("-ve Enemy in range");
            enemyRb = collision.gameObject.GetComponent<Rigidbody2D>();
            nEnemyDetect = true;
        }
        if (collision.gameObject.tag == "positiveEnemy")
        {
            Debug.Log("+ve Enemy inbound");
            enemyRb = collision.gameObject.GetComponent<Rigidbody2D>();
            pEnemyDetect = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //checking for enemy collision exit
        if (collision.gameObject.tag == "negativeEnemy")
        {
            Debug.Log("-ve Enemy not in range");
            enemyRb = null;
            nEnemyDetect = false;
        }
        if (collision.gameObject.tag == "positiveEnemy")
        {
            Debug.Log("+ve Enemy not in range");
            enemyRb = null;
            pEnemyDetect = false;
        }
    }

     void Update()
    {
        //negative enemy
        if (Input.GetKey(KeyCode.E) && nEnemyDetect)
        {     
                enemyRb.AddForce(magnetForce * Mathf.Sign(transform.localScale.x));
            
        }
        if (Input.GetKey(KeyCode.Q) && nEnemyDetect)
        {
            enemyRb.AddForce(-magnetForce * Mathf.Sign(transform.localScale.x));

        }

        //positive enemy
        if (Input.GetKey(KeyCode.E) && pEnemyDetect)
        {
            enemyRb.AddForce(-magnetForce * Mathf.Sign(transform.localScale.x));

        }
        if (Input.GetKey(KeyCode.Q) && pEnemyDetect)
        {
            enemyRb.AddForce(magnetForce * Mathf.Sign(transform.localScale.x));

        }
    }
}
