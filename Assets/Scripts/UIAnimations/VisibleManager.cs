using UnityEngine;

public abstract class VisibleManager : MonoBehaviour
{
    [SerializeField]protected bool isOpened;

    public void Open()
    {
        if (!isOpened)
        {
            DoOpen();           
            isOpened = true;
        }

    }

    public void Close()
    {
        if (isOpened)
        {
            DoClose();            
            isOpened = false;
        }
    }

    protected abstract void DoOpen();
    protected abstract void DoClose();
}

