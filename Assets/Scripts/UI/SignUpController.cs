﻿using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SignUpController:MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private TMP_InputField email;
    [SerializeField] private TMP_InputField username;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TMP_InputField repeatPassword;
    [Header("Actions")]
    [SerializeField] private LogInController logInController;
    [SerializeField] private MessageController messenger;
    [SerializeField] private Toggle remindMe;
    [SerializeField] private Button signUp;
    [SerializeField] private Button logIn;

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        logIn.onClick.AddListener(LogIn);
        signUp.onClick.AddListener(SignUp);
    }

    private void SignUp()
    {
        if(!CheckEmail.IsEmail(email.text))
        {
            messenger.ShowMessage("Error", "Email unvalid");
            return;
        }

        if(password.text != repeatPassword.text)
        {
            messenger.ShowMessage("Error", "Passwords not equal");
            return;
        }

        if(username.text == "")
        {
            messenger.ShowMessage("Error", "Username can`t be empty");
            return;
        }

        AuthData authData = new AuthData()
        {
            Email = email.text,
            Username = username.text,
            Password = password.text
        };

        Authentication.Instance.SignUp(authData, SuccessefullySignUp, ErrorSignUp);     
    }

    private void LogIn()
    {
        this.Close();
        logInController.Open();
    }

    private void SuccessefullySignUp()
    {
        if (remindMe.isOn)
            PlayerPrefs.SetInt(Authentication.RemindMeKey, 1);
        else
            PlayerPrefs.SetInt(Authentication.RemindMeKey, 0);

        StartGame();
    }

    private void ErrorSignUp(string message)
    {
        messenger.ShowMessage("Error", message);
    }

    private void StartGame()
    {
        Debug.LogError("Scene loading should be rewritten");
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }



}
