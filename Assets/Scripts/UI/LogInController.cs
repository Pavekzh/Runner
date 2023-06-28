using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LogInController:MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private TMP_InputField email;
    [SerializeField] private TMP_InputField password;

    [Header("Actions")]
    [SerializeField] private SignUpController signUpController;
    [SerializeField] private MessageController messenger;        
    [SerializeField] private GameObject panel;
    [SerializeField] private Toggle remindMe;
    [SerializeField] private Button signUp;
    [SerializeField] private Button logIn;

    public void Open()
    {
        panel.SetActive(true);
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        panel.SetActive(false);
        if (PlayerPrefs.GetString(Authentication.AuthDataKey) == "")
            SignUp();
        else
        {
            if (PlayerPrefs.GetInt(Authentication.RemindMeKey) == 1)
                Authentication.Instance.SilentLogin(StartGame, LoginError);
            else
                panel.SetActive(true);
        }


        signUp.onClick.AddListener(SignUp);
        logIn.onClick.AddListener(LogIn);
    }


    private void LogIn()
    {
        AuthData authData = new AuthData()
        {
            Email = email.text,
            Password = password.text
        };

        Authentication.Instance.LogIn(authData, SuccessefullyLogin, LoginError);
    }

    private void SignUp()
    {
        this.Close();
        signUpController.Open();
    }

    private void SuccessefullyLogin()
    {      
        if (remindMe.isOn)
            PlayerPrefs.SetInt(Authentication.RemindMeKey, 1);
        else
            PlayerPrefs.SetInt(Authentication.RemindMeKey, 0);

        StartGame();
    }

    private void LoginError(string message)
    {
        messenger.ShowMessage("Error", message);
        panel.SetActive(true);
    }

    private void StartGame()
    {
        Debug.LogError("Scene loading should be rewritten");
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
