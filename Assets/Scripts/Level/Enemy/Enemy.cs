using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float horSpeed;
    public float verSpeed;
    public float hittedSpeed;
    public float moveTimer;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public Transform target;
    public Rigidbody2D myRigidbody;
    public bool isHitted;

    public Vector2 movement;
    public Vector2 fleeing;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isHitted = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        moveTimer += Time.deltaTime;

        myRigidbody.AddForce(new Vector3(horSpeed, verSpeed, 0.0f));

        if (moveTimer >= 4)
        {

            myRigidbody.velocity = Vector2.zero;

        }

        if (moveTimer >= 5)
        {

            horSpeed = -horSpeed;
            verSpeed = -verSpeed;
            moveTimer = 0;
            
        }



    }

    private void FixedUpdate()
    {

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY));

        if (isHitted)
        {
            //Hitted();
        }

    }



    void Hitted()
    {
        myRigidbody.AddForce(transform.up * hittedSpeed);
        gameObject.SetActive(false);
        isHitted = false;
    }

}
