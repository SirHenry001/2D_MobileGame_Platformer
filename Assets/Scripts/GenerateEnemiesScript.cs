using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemiesScript : MonoBehaviour

    
{

    public GameObject theEnemy;
    public float xPos;
    public float yPos;
    public int enemyCount;
    public int enemiesOnGame;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < enemiesOnGame)
        {
            xPos = Random.Range(minX, maxX);
            yPos = Random.Range(minY, maxY);
            Instantiate(theEnemy, new Vector2(xPos, yPos), Quaternion.identity);
            yield return new WaitForSeconds(4f);
            enemyCount += 1;
        }
    }
  
}
