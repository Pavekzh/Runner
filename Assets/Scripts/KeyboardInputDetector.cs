using System;
using UnityEngine;

public class KeyboardInputDetector : InputDetector
{
    private const string startKey = "w";
    private const string upKey = "w";
    private const string downKey = "s";
    private const string leftKey = "a";
    private const string rightKey = "d";

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
        return Input.GetKeyDown(upKey);
    }
}