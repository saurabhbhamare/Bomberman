using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterService
{
    private CharacterSO characterSO1;
    private CharacterSO characterSO2;
    private CharacterView characterView1;
    private CharacterView characterView2;
    
    private BombService bombService;
    private EventService eventService;
    public CharacterService(CharacterSO characterSO1,CharacterSO characterSO2,CharacterView characterView1,CharacterView characterView2, BombService bombService,EventService eventService)
    {
        this.characterSO1 = characterSO1;
        this.characterSO2 = characterSO2;
        this.characterView1 = characterView1;
        this.characterView2 = characterView2;
        this.bombService = bombService;
        this.eventService = eventService;
        CharacterController characterController1 = new CharacterController(this.characterView1, characterSO1, bombService,this.eventService);
        CharacterController characterController2 = new CharacterController(this.characterView2, characterSO2, bombService,this.eventService);
        characterView1.SetCharacterController(characterController1);
        characterView2.SetCharacterController(characterController2);
    }
}
