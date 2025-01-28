using UnityEngine;
public class MainHandler : MonoBehaviour
{
    [SerializeField] private CharacterSO characterSO;
    [SerializeField] private CharacterView characterView;

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
        bombService = new BombService(bombPrefab,flamePrefab,bombParent,flameParent);
        characterService = new CharacterService(characterSO, characterView, bombService);     
    }

}
