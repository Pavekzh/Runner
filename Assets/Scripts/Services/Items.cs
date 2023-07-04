using UnityEngine;

public class Items:MonoBehaviour
{
    [SerializeField] private Transform itemsParent;

    public void OnEnable()
    {
        foreach (Transform item in itemsParent)
            item.gameObject.SetActive(true);
    }

}

