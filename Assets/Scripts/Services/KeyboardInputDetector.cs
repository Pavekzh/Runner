using UnityEngine;
using UnityEngine.EventSystems;

public class KeyboardInputDetector : InputDetector
{
    [SerializeField] private bool saveInputUp = true;
    [SerializeField] private float saveInputUpTime = 0.3f;

    private const string upKey = "w";
    private const string downKey = "s";
    private const string leftKey = "a";
    private const string rightKey = "d";

    private float savedInputUpTime = -1;

    public override bool CheckAnyInput()
    {
        if (Input.anyKeyDown && !EventSystem.current.IsPointerOverGameObject())
            return true;
        else
            return false;
    }

    public override Vector2 CheckInputDirection()
    {
        if (Input.GetKeyDown(rightKey))
            return Vector2.right;
        else if (Input.GetKeyDown(leftKey))
            return Vector2.left;
        else if (CheckUpInput())
            return Vector2.up;
        else if (Input.GetKeyDown(downKey))
            return Vector2.down;
        else
            return Vector2.zero;
    }

    public bool CheckUpInput()
    {
        if (Input.GetKeyDown(upKey))
        {
            savedInputUpTime = Time.realtimeSinceStartup;
            return true;
        }
        else if (saveInputUp && Time.realtimeSinceStartup - savedInputUpTime < saveInputUpTime)
            return true;
        else return false;
    }
}