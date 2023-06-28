using System;
using UnityEngine;

public class SwipeInputDetector : InputDetector
{
    [SerializeField][Range(0,1)] private float swipeTreshold = 0.2f;    
    [SerializeField] private bool saveInputUp = true;
    [SerializeField] private float saveInputUpTime = 0.3f;


    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private bool isSwipeHandled;
    private bool isSavedInputUp = false;
    private float savedInputUpTime = -1;

    public override bool CheckAnyInput()
    {
        return Input.touchCount > 0;
    }

    public override Vector2 CheckInputDirection()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
                touchEndPos = touch.position;
                isSwipeHandled = false;
            }

            if(touch.phase == TouchPhase.Moved)
            {
                if (!isSwipeHandled)
                {
                    touchEndPos = touch.position;
                    Vector2 swipeDirection;

                    isSwipeHandled = CheckSwipe(out swipeDirection);
                    SaveInputUp(swipeDirection);

                    return swipeDirection;
                }
            }
        }

        if (CheckSavedInputUp())
            return Vector2.up;
        else
            return Vector2.zero;
    }

    private void SaveInputUp(Vector2 inputDirection)
    {
        if(saveInputUp && inputDirection.y == 1)
        {
            isSavedInputUp = true;
            savedInputUpTime = Time.realtimeSinceStartup;
        }
    }

    private bool CheckSavedInputUp()
    {
        if (isSavedInputUp)
        {
            if ((Time.realtimeSinceStartup - savedInputUpTime) < saveInputUpTime)
                return true;
            else
                isSavedInputUp = false;

        }
        return false;
    }

    private bool CheckSwipe(out Vector2 direction)
    {
        float deltaX = MathF.Abs(touchEndPos.x - touchStartPos.x) / Screen.width;
        float deltaY = MathF.Abs(touchEndPos.y - touchStartPos.y) / Screen.width;

        if (deltaX > swipeTreshold && deltaX > deltaY)
        {
            if (touchEndPos.x > touchStartPos.x)
                direction = Vector2.right;
            else
                direction = Vector2.left;

            return true;
        }
        else if (deltaY > swipeTreshold)
        {
            if (touchEndPos.y > touchStartPos.y)
                direction = Vector2.up;
            else
                direction = Vector2.down;

            return true;
        }
        else
            direction = Vector2.zero;
        return false;

    }
}

