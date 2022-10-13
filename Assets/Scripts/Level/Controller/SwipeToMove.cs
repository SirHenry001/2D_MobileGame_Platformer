using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeToMove : MonoBehaviour
{

    //VARAIBLE WHAT IS THE MOVABLE TARGET ON THE SCREEN
    public GameObject fingerTarget;
    public GameObject movingTarget;

    //POSITIONS TO MOVE
    public GameObject[] movePosition;
    public int positionNumber = 1;

    //VARIABLES TO LAYERS
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        movingTarget.transform.position = movePosition[2].transform.position;
    }



    // Update is called once per frame
    private void Update()
    {

        if (positionNumber <= 1)
        {
            movingTarget.transform.position = movePosition[0].transform.position;
            positionNumber = 1;
        }

        if (positionNumber == 2)
        {
            movingTarget.transform.position = movePosition[1].transform.position;
            positionNumber = 2;
        }

        if (positionNumber == 3)
        {
            movingTarget.transform.position = movePosition[2].transform.position;
            positionNumber = 3;   
        }

        if (positionNumber == 4)
        {
            movingTarget.transform.position = movePosition[3].transform.position;
            positionNumber = 4;
        }

        if (positionNumber >= 5)
        {
            movingTarget.transform.position = movePosition[4].transform.position;
            positionNumber = 5;
        }

        RaycastHit hit;
        Ray ray;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {

            fingerTarget.transform.position = hit.point;

            if (Input.GetButtonDown("Fire1") && fingerTarget.transform.position.x < movingTarget.transform.position.x)
            {

                positionNumber += 1;

            }

            if (Input.GetButtonDown("Fire1") && fingerTarget.transform.position.x > movingTarget.transform.position.x)
            {
                positionNumber -= 1;
            }

        }

    }

    public void MoveLeft()
    {

    }
}
