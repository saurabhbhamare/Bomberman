using UnityEngine;
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


    private CharacterService characterService;
    private BombService bombService;

    private void Start()
    {
        InitServices();
    }

    private void InitServices()
    {
        bombService = new BombService(bombData,bombPrefab,flamePrefab,bombParent,flameParent);
        characterService = new CharacterService(characterSO, characterView, bombService);     
       // AudioService 
    }

}
