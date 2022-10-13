using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public float startTimer;
    public float cameraSpeed;

    public CollisionScript collisionScript;


    // Start is called before the first frame update
    void Start()
    {
        collisionScript = GameObject.Find("Player").GetComponent<CollisionScript>();

        collisionScript.gameOver = true;

    }

    // Update is called once per frame
    void Update()
    {
        startTimer += Time.deltaTime;

        if (startTimer >= 5 && startTimer < 6)
        {
            collisionScript.gameOver = false;
        }

        if (startTimer >= 6)
        {
            transform.Translate(Vector3.up * cameraSpeed * Time.deltaTime, Space.World);
        }

    }
}
