using UnityEngine;

class StartupBootstrap : MonoBehaviour
{
    [Header("Systems")]
    [SerializeField] private Authentication authentication;
    [SerializeField] private SceneLoader sceneLoader;

    [Header("UI")]
    [SerializeField] private LogInController logIn;
    [SerializeField] private SignUpController signUp;
    [SerializeField] private MessageController messanger;

    private void Awake()
    {
        BootstrapLogIn();
        BootstrapSignUp();
    }

    private void BootstrapLogIn()
    {
        logIn.InitDependencies(authentication, signUp, messanger,sceneLoader);
    }

    private void BootstrapSignUp()
    {
        signUp.InitDependencies(authentication, logIn, messanger, sceneLoader);
    }
}