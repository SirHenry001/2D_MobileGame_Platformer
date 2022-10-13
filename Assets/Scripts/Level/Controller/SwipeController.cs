using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{

    public SwipeToMove2 swipeToMove;
    public CollisionScript collisionScript;
    public Rigidbody2D myRigidbody;
    public Transform player;
    public Vector3 desiredPosition;

    public float speed;
    public float jumpSpeed;
    public float landingSpeed;

    

    private void Start()
    {
        swipeToMove = GameObject.Find("Main Camera").GetComponent<SwipeToMove2>();
        collisionScript = GameObject.Find("Player").GetComponent<CollisionScript>();
        myRigidbody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(swipeToMove.swipeLeft2 && collisionScript.gameOver == false)
        {
            //desiredPosition += Vector3.left;
            myRigidbody.AddForce(new Vector3(-speed, 0.0f, 0.0f));
            collisionScript.facingRight = false;
            collisionScript.TurnCheck();
        }
        if (swipeToMove.swipeRight2 && collisionScript.gameOver == false)
        {
            //desiredPosition += Vector3.right;
            myRigidbody.AddForce(new Vector3(speed, 0.0f, 0.0f));
            collisionScript.facingRight = true;
            collisionScript.TurnCheck();
        }
        if (swipeToMove.swipeUp2 && collisionScript.gameOver == false)
        {
            //desiredPosition += Vector3.up*jumpSpeed;
            myRigidbody.AddForce(new Vector3(0.0f, jumpSpeed, 0.0f));
        }
        if (swipeToMove.swipeDown2 && collisionScript.gameOver == false)
        {
            //desiredPosition += Vector3.down*jumpSpeed;
            myRigidbody.AddForce(new Vector3(0.0f, -landingSpeed, 0.0f));
        }

        //player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, speed * Time.deltaTime);

        if (swipeToMove.Tap)
        {
            Debug.Log("Tapp!");
        }
    }

    public void MovePlayer()
    {
        myRigidbody.AddForce(new Vector3(0.0f, jumpSpeed, 0.0f));
    }

}
