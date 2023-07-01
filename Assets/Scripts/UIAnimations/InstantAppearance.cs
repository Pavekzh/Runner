using UnityEngine;

public class InstantAppearance : VisibleManager
{
    [SerializeField] private GameObject target;

    protected override void DoClose()
    {
        target.SetActive(false);
    }

    protected override void DoOpen()
    {
        target.SetActive(true);
    }
}
