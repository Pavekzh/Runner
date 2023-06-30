using UnityEngine;
using TMPro;

public class LeaderboardRecord : MonoBehaviour
{
    [SerializeField] TMP_Text positionValue;
    [SerializeField] TMP_Text usernameValue;
    [SerializeField] TMP_Text recordValue;

    public void SetRecord(string username,string value,int position)
    {
        usernameValue.text = username;
        recordValue.text = value;
        positionValue.text = position.ToString();
    }
}
