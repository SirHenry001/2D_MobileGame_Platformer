using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    //TIMER THAT DETERMINE PLAYER SCORE
    public float timer;
    public float reward;
    public float rewardScore1, rewardScore2, rewardScore3;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public int starsGained;
    static int starsRecord;

    public bool facingRight;
    public bool gameOver = false;

    public GameObject Counter1;
    public GameObject Counter2;
    public GameObject Counter3;
    public GameObject CounterText;


    public GameObject levelPopUp;
    public GameObject[] stars;
    public int nextLevel;

    public GameManager gameManager;
    public SwipeToMove2 swipeToMove;
    public CameraScript cameraScript;

    private void Start()
    {


        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        cameraScript = GameObject.Find("Main Camera").GetComponent<CameraScript>();

        StartCoroutine(CountStart());
    }

    private void Update()
    {

        if (!gameOver)
        {
            timer += Time.deltaTime;
            cameraScript.cameraSpeed = 1;
        }

        if(gameOver)
        {
            cameraScript.cameraSpeed = 0;
        }


    }

    public void FixedUpdate()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY));


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Checkpoint")
        {
            reward = 1;
        }

        if (collision.gameObject.tag == "Checkpoint2")
        {
            reward = 2;
        }

        if (collision.gameObject.tag == "Checkpoint3")
        {
            reward = 3;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !gameOver)
        {
            levelPopUp.SetActive(true);
            gameOver = true;
            
            for(int i = 0; i < stars.Length; i++)
            {
                stars[i].SetActive(false);
            }

            if (reward == rewardScore1)
            {
                starsGained = 1;
            }

            if (reward == rewardScore2)
            {
                starsGained = 2;
            }

            if (reward == rewardScore3)
            {
                starsGained = 3;
            }

            if(starsGained > starsRecord)
            {
                starsRecord = starsGained;
            }

            gameManager.level1Stars = starsRecord;

            StartCoroutine(StarAppear());

        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeadZone" && !gameOver)
        {
            levelPopUp.SetActive(true);
            gameOver = true;
        }
    }

    public IEnumerator StarAppear()
    {
        yield return new WaitForSeconds(1);

        for (int i = 0; i < starsGained; i++)
        {
            stars[i].SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void LevelScreenActive(int level)
    {
        levelPopUp.SetActive(true);
        nextLevel = level;
    }

    public void OpenLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }

    public IEnumerator CountStart()
    {

        yield return new WaitForSeconds(1f);

        Counter1.SetActive(true);
        yield return new WaitForSeconds(1f);
        Counter1.SetActive(false);
        Counter2.SetActive(true);
        yield return new WaitForSeconds(1f);
        Counter2.SetActive(false);
        Counter3.SetActive(true);
        yield return new WaitForSeconds(1f);
        Counter3.SetActive(false);
        CounterText.SetActive(true);
        yield return new WaitForSeconds(1f);
        CounterText.SetActive(false);
    }



    public void TurnCheck()
    {
        if (facingRight == true && transform.localScale.x < 0)
        {
            if(transform.localScale.x < 0)
            {
                Flip();
            }

        }

        if(facingRight == false && transform.localScale.x > 0)
        {
            Flip();
        }

        // FACING THE PLAYER TO WALKING DIRECTION REGARDING TO PLAYERS HORIZONTAL MOVEMENT 
        
    }

    public void Flip()
    {

        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1f);

    }

}
