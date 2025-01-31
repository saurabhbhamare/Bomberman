using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterService
{
    private CharacterSO characterSO;
    private CharacterView characterView1;
    private BombService bombService;
    public CharacterService(CharacterSO characterSO, CharacterView characterView, BombService bombService)
    {
        this.characterSO = characterSO;
        characterView1 = characterView;
        this.bombService = bombService;
        CharacterController characterController1 = new CharacterController(this.characterView1, characterSO, bombService);
        characterView1.SetCharacterController(characterController1);
    }
}
