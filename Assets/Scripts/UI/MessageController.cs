﻿using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text message;
    [SerializeField] private Button okButton;

    private void Start()
    {
        okButton.onClick.AddListener(Close);
    }

    public void ShowMessage(string Title, string Message)
    {
        this.title.text = Title;
        this.message.text = Message;

        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}