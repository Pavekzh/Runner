using UnityEngine;

public abstract class InputDetector:MonoBehaviour
{
    public abstract bool CheckStartInput();
    public abstract bool CheckUpInput();
    public abstract bool CheckDownInput();
    public abstract bool CheckLeftInput();
    public abstract bool CheckRightInput();
}
