using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeToMove2 : MonoBehaviour
{
    public bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    public bool isDragging = false;
    public Vector2 startTouch, swipeDelta;

    public float deadZone;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        #region Standalone Inputs

        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }

        else if( (Input.GetMouseButtonUp(0)))
        {
            isDragging = false;
            Reset();
        }

        #endregion

        #region Mobile inputs

        if (Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                isDragging = true;
                tap = true;
                startTouch = Input.touches[0].position;
            }
            else if ( Input.touches[0].phase ==  TouchPhase.Ended ||  Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                Reset();
            }

        }

        #endregion

        //CALCULATE THE DISTANCE
        swipeDelta = Vector2.zero;
        if(isDragging)
        {
            if(Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }

            else if(Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        //DID WE CROSS THE DEADZONE?
        if (swipeDelta.magnitude > deadZone)
        {

            //WHICH DIRECTION IS THE SWIPE?

            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                //LEFT OR RIGHT
                if(x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }
            }

            else
            {
                //UP OR DOWN
                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }
            }

            Reset();
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }

    public bool Tap { get { return tap; } }
    public Vector2 switeDelta { get { return swipeDelta; } }
    public bool swipeLeft2 { get { return swipeLeft; } }
    public bool swipeRight2 { get { return swipeRight; } }
    public bool swipeUp2 { get { return swipeUp; } }
    public bool swipeDown2 { get { return swipeDown; } }

}
