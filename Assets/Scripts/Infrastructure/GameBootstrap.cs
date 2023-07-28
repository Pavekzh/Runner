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
    [SerializeField] CharacterModel character;
    [SerializeField] PauseController pause;

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
        BootstrapPause();
        
        BootstrapCharacter();
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
        inRunUI.InitDependencies(scoreCounter,character);
    }    

    private void BootstrapPause()
    {
        pause.InitDependencies(sceneLoader);
    }
    
    private void BootstrapGameOver()
    {
        gameOver.InitDependecies(playerProfile,sceneLoader);
    }

    private void BootstrapCharacter()
    {
        character.InitDependecies(inputDetector, scoreCounter, inRunUI, mainMenu, gameOver);
    }

}
