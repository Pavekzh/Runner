using UnityEngine;

public abstract class InputDetector:MonoBehaviour
{
    public abstract Vector2 CheckInputDirection();
    public abstract bool CheckAnyInput();
}
