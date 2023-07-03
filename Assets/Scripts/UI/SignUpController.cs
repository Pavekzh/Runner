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
    [SerializeField] private VisibleManager visibleManager;
    [SerializeField] private Toggle remindMe;
    [SerializeField] private Button signUp;
    [SerializeField] private Button logIn;

    private LogInController logInController;
    private MessageController messenger;
    private Authentication authentication;
    private SceneLoader sceneLoader;

    public void InitDependencies(Authentication authentication, LogInController login, MessageController messenger,SceneLoader sceneLoader)
    {
        this.authentication = authentication;
        this.logInController = login;
        this.messenger = messenger;
        this.sceneLoader = sceneLoader;
    }

    public void Open()
    {
        visibleManager.Open();
    }

    public void Close()
    {
        visibleManager.Close();
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

        authentication.SignUp(authData, SuccessefullySignUp, ErrorSignUp);     
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
        sceneLoader.LoadGame();
    }



}
