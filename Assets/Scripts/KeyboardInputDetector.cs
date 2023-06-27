using UnityEngine;

public class KeyboardInputDetector : InputDetector
{
    [SerializeField]private float keepInputUpTime = 0.3f;

    private const string startKey = "w";
    private const string upKey = "w";
    private const string downKey = "s";
    private const string leftKey = "a";
    private const string rightKey = "d";

    private float lastTimeUpInput = -1;

    public override bool CheckStartInput()
    {
        return Input.GetKeyDown(startKey);
    }

    public override bool CheckDownInput()
    {
        return Input.GetKeyDown(downKey);
    }

    public override bool CheckLeftInput()
    {
        return Input.GetKeyDown(leftKey);
    }

    public override bool CheckRightInput()
    {
        return Input.GetKeyDown(rightKey);
    }

    public override bool CheckUpInput()
    {
        if (Input.GetKeyDown(upKey))
        {
            lastTimeUpInput = Time.realtimeSinceStartup;
            return true;
        }
        else if (Time.realtimeSinceStartup - lastTimeUpInput < keepInputUpTime)
            return true;
        else return false;
    }
}