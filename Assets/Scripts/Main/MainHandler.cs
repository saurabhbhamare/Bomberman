using UnityEngine;
using UnityEngine.Tilemaps;
public class MainHandler : MonoBehaviour
{

    [Header("Character References")]
    [SerializeField] private CharacterSO characterSO;
    [SerializeField] private CharacterView characterView;

    [Header("Bomb and Flame References")]
    [SerializeField] private BombSO bombData;
    [SerializeField] private Bomb bombPrefab;
    [SerializeField] private Flame flamePrefab;
    [SerializeField] Transform bombParent;
    [SerializeField] Transform flameParent;
    [Header("PowerUps Data")]
    [SerializeField] private PowerUpSO powerUpsData;

    [SerializeField] LayerMask obstacleLayerMask;
    [SerializeField] private Tilemap destructibleTilemap;
    [SerializeField] private Destructible destructibleWall;

    [SerializeField] private GameObject destructibleObj;

    private CharacterService characterService;
    private BombService bombService;
    private PowerUpService powerUpService;
    private EventService eventService;
    private void Start()
    {
        InitServices();
        RegisterEventListeners();
    }

    private void InitServices()
    {
        eventService = new EventService();
        bombService = new BombService(bombData, bombPrefab, flamePrefab, bombParent, flameParent, obstacleLayerMask, destructibleTilemap,destructibleWall,destructibleObj,eventService);
        characterService = new CharacterService(characterSO, characterView, bombService,eventService);
        powerUpService = new PowerUpService(powerUpsData,eventService);
       
        // AudioService 
    }
    //Game States
    
    private void RegisterEventListeners()
    {
        
    }
    public void GameOver()
    {

    }
}
