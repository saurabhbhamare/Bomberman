using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterService
{
    private CharacterSO characterSO;
    private CharacterView characterView1;
    
    private BombService bombService;
    private EventService eventService;
    public CharacterService(CharacterSO characterSO, CharacterView characterView, BombService bombService,EventService eventService)
    {
        this.characterSO = characterSO;
        characterView1 = characterView;
        this.bombService = bombService;
        this.eventService = eventService;
        CharacterController characterController1 = new CharacterController(this.characterView1, characterSO, bombService,this.eventService);
        characterView1.SetCharacterController(characterController1);
    }
}
