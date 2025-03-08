using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;
public class MainHandler : MonoBehaviour
{
    [Header("Character References")]
    [SerializeField] private CharacterSO characterSO1;
    [SerializeField] private CharacterSO characterSO2;
    [SerializeField] private CharacterView characterView1;
    [SerializeField] private CharacterView characterView2;
    [SerializeField] private CharacterHUD characterHUD1;
    [SerializeField] private CharacterHUD characterHUD2;

    [Header("Bomb and Flame References")]
    [SerializeField] private BombSO bombData;
    [SerializeField] private Bomb bombPrefab;
    [SerializeField] private Flame flamePrefab;
    [SerializeField] Transform bombParent;
    [SerializeField] Transform flameParent;

    [Header("PowerUps Data")]
    [SerializeField] private PowerUpSO powerUpsData;

    [Header("Destructibles")]
    [SerializeField] LayerMask obstacleLayerMask;
    [SerializeField] private Tilemap destructibleTilemap;
    [SerializeField] private Destructible destructibleWall;
    [SerializeField] private GameObject destructibleObj;

    //Services
    private CharacterService characterService;
    private BombService bombService;
    private PowerUpService powerUpService;
    private EventService eventService;

    //GameOver UI
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI gameOverText;
    private void Start()
    {
        InitServices();
        RegisterEventListeners();
    }
    private void InitServices()
    {
        eventService = new EventService();
        bombService = new BombService(bombData, bombPrefab, flamePrefab, bombParent, flameParent, obstacleLayerMask, destructibleTilemap, destructibleWall, destructibleObj, eventService);
        characterService = new CharacterService(characterSO1, characterSO2, characterView1, characterView2, bombService, eventService,characterHUD1,characterHUD2);
        powerUpService = new PowerUpService(powerUpsData, eventService);
    }
    private void RegisterEventListeners()
    {
        eventService.OnGameOver.AddListener(GameOver);
    }
    public void GameOver(CharacterType deadCharacterType)
    {
        ShowGameOverUI();
        SetGameOverText(deadCharacterType);
    }
    public void ShowGameOverUI()
    {
        gameOverPanel.SetActive(true);
    }
    public void SetGameOverText(CharacterType deadCharacterType)
    {
        if (deadCharacterType == CharacterType.CHARACTER1)
        {
            gameOverText.text = "Black won the game :)";
        }
        else
        {
            gameOverText.text = "White won the game :)";
        }
    }
}
