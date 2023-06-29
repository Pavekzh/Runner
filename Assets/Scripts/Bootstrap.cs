using UnityEngine;

class Bootstrap:MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] InputDetector inputDetector;
    [SerializeField] RunDistanceCounter distanceCounter;
    [SerializeField] GameOverController gameOverController;
    [Header("Dependent")]
    [SerializeField] Character character;
    [SerializeField] CharacterDeath characterDeath;


    private void Awake()
    {        
        BootstrapCharacter();
        BootstrapCharacterDeath();

    }

    private void BootstrapCharacter()
    {
        character.InitDependecies(inputDetector, distanceCounter);
    }

    private void BootstrapCharacterDeath()
    {
        characterDeath.InitDependecies(gameOverController);
    }
}
