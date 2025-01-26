using UnityEngine;
public class MainHandler : MonoBehaviour
{
    [SerializeField] private CharacterSO characterSO;
    [SerializeField] private CharacterView characterView;

    private CharacterService characterService;

    private void Start()
    {
        InitServices();
    }

    private void InitServices()
    {
        characterService = new CharacterService(characterSO, characterView);
    }

}
