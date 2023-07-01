using UnityEngine;

class GameBootstrap:MonoBehaviour
{
    [Header("Systems")]
    [SerializeField] InputDetector inputDetector;
    [SerializeField] ScoreCounter scoreCounter;    
    [SerializeField] WorldGenerator worldGenerator;
    [SerializeField] PlayerProfile playerProfile;
    [SerializeField] SceneLoader sceneLoader;

    [Header("Character")]    
    [SerializeField] Character character;
    [SerializeField] CharacterItems characterItems;
    [SerializeField] UISwitcher uiSwitcher;

    [Header("UI")]    
    [SerializeField] InRunUIController inRunUI;
    [SerializeField] GameOverController gameOver;
    [SerializeField] MainMenuController mainMenu;


    private void Awake()
    {                
        BootstrapWorldGenerator();

        BootstrapMainMenu();
        BootstrapInRunUI();
        BootstrapGameOver();        
        
        BootstrapCharacter();
        BootstrapUISwitcher();
    }

    private void BootstrapWorldGenerator()
    {
        worldGenerator.InitDependecies(scoreCounter);
    }

    private void BootstrapMainMenu()
    {
        mainMenu.InitDependencies(playerProfile,sceneLoader);
    }

    private void BootstrapInRunUI()
    {
        inRunUI.InitDependencies(scoreCounter,characterItems);
    }    
    
    private void BootstrapGameOver()
    {
        gameOver.InitDependecies(playerProfile,sceneLoader);
    }

    private void BootstrapCharacter()
    {
        character.InitDependecies(inputDetector, scoreCounter);
    }

    private void BootstrapUISwitcher()
    {
        uiSwitcher.InitDependencies(mainMenu, inRunUI, gameOver);
    }
}
