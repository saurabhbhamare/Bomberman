public class CharacterService
{
    //Character Data
    private CharacterSO characterSO1;
    private CharacterSO characterSO2;
    private CharacterView characterView1;
    private CharacterView characterView2;

    private CharacterHUD characterHUD1;
    private CharacterHUD characterHUD2;
    
    private BombService bombService;
    private EventService eventService;


    public CharacterService(CharacterSO characterSO1,CharacterSO characterSO2,CharacterView characterView1,CharacterView characterView2, BombService bombService,EventService eventService,CharacterHUD characterHUD1, CharacterHUD characterHUD2)
    {
        this.characterSO1 = characterSO1;
        this.characterSO2 = characterSO2;
        this.characterView1 = characterView1;
        this.characterView2 = characterView2;
        this.bombService = bombService;
        this.eventService = eventService;
        this.characterHUD1 = characterHUD1;
        this.characterHUD1 = characterHUD2;
        CharacterController characterController1 = new CharacterController(this.characterView1, characterSO1, bombService,this.eventService,characterHUD1);
        CharacterController characterController2 = new CharacterController(this.characterView2, characterSO2, bombService,this.eventService,characterHUD2);
        characterView1.SetCharacterController(characterController1);
        characterView2.SetCharacterController(characterController2);
    }
}
